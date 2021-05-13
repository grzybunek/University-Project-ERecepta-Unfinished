namespace Prescription.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Prescription.Domain.Services;
    using Prescription.Domain;
    using System.Data.SqlClient;
    using Dapper;
    using System.Data.Common;

    public class PrescriptionRepository : IPrescriptionRepository
    {
        public PrescriptionRepository()
        { }

        public async Task AddPrescriptionAsync(PrescriptionObject prescription)
        {
            const string getAddedRowIdQueryQuery = @"SELECT CAST(SCOPE_IDENTITY() as int)";

            //utworzenie połączenia do bazy danych, klauzula using wykorzystywana jest żebyśmy nie musieli przejmować się zamykaniem polączenia
            using (var dbConnection = new SqlConnection(Constants.connectionString))
            {
                dbConnection.Open();
                using (DbTransaction transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        const string insertPrescriptionQuery = @"INSERT INTO Prescription (IdDoctor, IdPatient, Date, DateOfExpiration) VALUES (@idDoctor, @idPatient, @date, @dateOfExpiration);";
                        int prescriptionId = await dbConnection.QueryFirstAsync<int>(insertPrescriptionQuery + ";" + getAddedRowIdQueryQuery, new { idDoctor = prescription.IdDoctor, idPatient = prescription.IdPatient, date = prescription.Date, DateOfExpiration = prescription.DateOfExpiration }, transaction);

                        var medicinesIds = new List<int>();

                        const string insertMedicinesQuery = @"INSERT INTO Medicine (Name, DailyDose) VALUES (@name,@dailyDose);";

                        foreach (var medicine in prescription.Medicines)
                            medicinesIds.Add(await dbConnection.QueryFirstAsync<int>(insertMedicinesQuery + ";" + getAddedRowIdQueryQuery, new { name = medicine.Name, dailyDose = medicine.DailyDose }, transaction));

                        const string insertMedicinePrescriptionQuery = @"INSERT INTO MedicinePrescription (MedicineId, PrescriptionId) VALUES (@medicineId,@prescriptionId);";
                        foreach (var medicineId in medicinesIds)
                            await dbConnection.QueryAsync(insertMedicinePrescriptionQuery, new { medicineId = medicineId, prescriptionId = prescriptionId }, transaction);
                        //commit transakcji
                        transaction.Commit();

                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public async Task DeletePrescriptionAsync(int PrescriptionId)
        {

            //utworzenie połączenia do bazy danych, klauzula using wykorzystywana jest żebyśmy nie musieli przejmować się zamykaniem polączenia
            using (var dbConnection = new SqlConnection(Constants.connectionString))
            {
                string selectMedicinePrescriptions = $@"SELECT * FROM MedicinePrescription WHERE PrescriptionId={PrescriptionId};";
                var medicinePrescriptions = (await dbConnection.QueryAsync(selectMedicinePrescriptions)).Select(x => new { MedicineId = x.MedicineId, PrescriptionId = x.PrescriptionId });

                dbConnection.Open();
                using (DbTransaction transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        foreach (var medicinePrescription in medicinePrescriptions)
                        {
                            var deleteMedicine = $@"DELETE FROM Medicine WHERE Id=@Id";
                
                            await dbConnection.ExecuteAsync(deleteMedicine, new { Id = medicinePrescription.MedicineId }, transaction);
                        }

                        string deletePrescription = $@"DELETE FROM Prescription WHERE Id={PrescriptionId}";
                        await dbConnection.ExecuteAsync(deletePrescription, transaction: transaction);

                        //commit transakcji
                        transaction.Commit();

                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public async Task<IEnumerable<PrescriptionObject>> GetAllAsync()
        {
            using (var dbConnection = new SqlConnection(Constants.connectionString))
            {

                const string selectMedicinePrescriptions = @"SELECT * FROM MedicinePrescription";

                var medicinePrescriptions = (await dbConnection.QueryAsync(selectMedicinePrescriptions)).Select(x => new { MedicineId = x.MedicineId, PrescriptionId = x.PrescriptionId });

                const string selectPrescriptionsQuery = @"SELECT * FROM Prescription";

                var prescriptions = await dbConnection.QueryAsync<PrescriptionObject>(selectPrescriptionsQuery);

                const string selectMedicinesQuery = @"SELECT * FROM Medicine";

                var medicines = await dbConnection.QueryAsync<Medicine>(selectMedicinesQuery);

                foreach (var prescription in prescriptions)
                {
                    var medicinesIdForGivenPrescription = medicinePrescriptions.Where(x => x.PrescriptionId == prescription.Id).Select(x => x.MedicineId);
                    var medicinesForGivenPrescription = medicines.Where(x => medicinesIdForGivenPrescription.Contains(x.Id));
                    prescription.AddMedicines(medicinesForGivenPrescription);
                }

                return prescriptions;

            }
        }

        public async Task<IEnumerable<PrescriptionObject>> GetAllDoctorPrescriptions(int idDoctor)
        {

            using (var dbConnection = new SqlConnection(Constants.connectionString))
            {
                string selectPrescriptionsQuery = $@"SELECT * FROM Prescription P WHERE P.IdDoctor={idDoctor}";

                var prescriptions = await dbConnection.QueryAsync<PrescriptionObject>(selectPrescriptionsQuery);


                const string selectMedicinePrescriptions = @"SELECT * FROM MedicinePrescription";

                var medicinePrescriptions = (await dbConnection.QueryAsync(selectMedicinePrescriptions)).Select(x => new { MedicineId = x.MedicineId, PrescriptionId = x.PrescriptionId });


                const string selectMedicinesQuery = @"SELECT * FROM Medicine";

                var medicines = await dbConnection.QueryAsync<Medicine>(selectMedicinesQuery);

                foreach (var prescription in prescriptions)
                {
                    var medicinesIdForGivenPrescription = medicinePrescriptions.Where(x => x.PrescriptionId == prescription.Id).Select(x => x.MedicineId);
                    var medicinesForGivenPrescription = medicines.Where(x => medicinesIdForGivenPrescription.Contains(x.Id));
                    prescription.AddMedicines(medicinesForGivenPrescription);
                }

                return prescriptions;
            }
        }

        public async Task<IEnumerable<PrescriptionObject>> GetAllPatientPrescriptions(int idPatient)
        {
            using (var dbConnection = new SqlConnection(Constants.connectionString))
            {
                string selectPrescriptionsQuery = $@"SELECT * FROM Prescription P WHERE P.IdPatient={idPatient}";

                var prescriptions = await dbConnection.QueryAsync<PrescriptionObject>(selectPrescriptionsQuery);


                const string selectMedicinePrescriptions = @"SELECT * FROM MedicinePrescription";

                var medicinePrescriptions = (await dbConnection.QueryAsync(selectMedicinePrescriptions)).Select(x => new { MedicineId = x.MedicineId, PrescriptionId = x.PrescriptionId });


                const string selectMedicinesQuery = @"SELECT * FROM Medicine";

                var medicines = await dbConnection.QueryAsync<Medicine>(selectMedicinesQuery);

                foreach (var prescription in prescriptions)
                {
                    var medicinesIdForGivenPrescription = medicinePrescriptions.Where(x => x.PrescriptionId == prescription.Id).Select(x => x.MedicineId);
                    var medicinesForGivenPrescription = medicines.Where(x => medicinesIdForGivenPrescription.Contains(x.Id));
                    prescription.AddMedicines(medicinesForGivenPrescription);
                }

                return prescriptions;
            }
        }
    }
}
