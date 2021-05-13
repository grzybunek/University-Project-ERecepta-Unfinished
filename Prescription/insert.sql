INSERT INTO Medicine(Name, DailyDose) VALUES ('Beer', 3)
INSERT INTO Medicine(Name, DailyDose) VALUES ('Gripex', 2)
INSERT INTO Medicine(Name, DailyDose) VALUES ('Moderna', 2)
INSERT INTO Medicine(Name, DailyDose) VALUES ('Abacavir', 1)
INSERT INTO Medicine(Name, DailyDose) VALUES ('Atenol', 5)
INSERT INTO Medicine(Name, DailyDose) VALUES ('Rutinoscrobin', 3)
INSERT INTO Medicine(Name, DailyDose) VALUES ('Codeine', 6)
INSERT INTO Medicine(Name, DailyDose) VALUES ('Dapsone', 2)
INSERT INTO Medicine(Name, DailyDose) VALUES ('Dopamine', 10)
INSERT INTO Medicine(Name, DailyDose) VALUES ('Enalapril', 3)
INSERT INTO Medicine(Name, DailyDose) VALUES ('Mesna', 4)
INSERT INTO Medicine(Name, DailyDose) VALUES ('Morphine', 1)
INSERT INTO Medicine(Name, DailyDose) VALUES ('Potassium', 2)
INSERT INTO Medicine(Name, DailyDose) VALUES ('Calcium', 4)

INSERT INTO Prescription(IdDoctor, IdPatient,Date, DateOfExpiration) VALUES (1, 1,GETDATE(), GETDATE())
INSERT INTO Prescription(IdDoctor, IdPatient,Date, DateOfExpiration) VALUES (1, 2,GETDATE(), GETDATE())
INSERT INTO Prescription(IdDoctor, IdPatient,Date, DateOfExpiration) VALUES (1, 3,GETDATE(), GETDATE())
INSERT INTO Prescription(IdDoctor, IdPatient,Date, DateOfExpiration) VALUES (2, 4,GETDATE(), GETDATE())
INSERT INTO Prescription(IdDoctor, IdPatient,Date, DateOfExpiration) VALUES (2, 5,GETDATE(), GETDATE())
INSERT INTO Prescription(IdDoctor, IdPatient,Date, DateOfExpiration) VALUES (3, 6,GETDATE(), GETDATE())
INSERT INTO Prescription(IdDoctor, IdPatient,Date, DateOfExpiration) VALUES (3, 7,GETDATE(), GETDATE())
INSERT INTO Prescription(IdDoctor, IdPatient,Date, DateOfExpiration) VALUES (3, 8,GETDATE(), GETDATE())
INSERT INTO Prescription(IdDoctor, IdPatient,Date, DateOfExpiration) VALUES (4, 9,GETDATE(), GETDATE())
INSERT INTO Prescription(IdDoctor, IdPatient,Date, DateOfExpiration) VALUES (4, 10,GETDATE(), GETDATE())

  INSERT INTO MedicinePrescription(MedicineId,PrescriptionId) VALUES (1, 1)
  INSERT INTO MedicinePrescription(MedicineId,PrescriptionId) VALUES (2, 1)
  INSERT INTO MedicinePrescription(MedicineId,PrescriptionId) VALUES (3, 2)
  INSERT INTO MedicinePrescription(MedicineId,PrescriptionId) VALUES (4, 3)
  INSERT INTO MedicinePrescription(MedicineId,PrescriptionId) VALUES (5, 3)
  INSERT INTO MedicinePrescription(MedicineId,PrescriptionId) VALUES (6, 4)
  INSERT INTO MedicinePrescription(MedicineId,PrescriptionId) VALUES (7, 5)
  INSERT INTO MedicinePrescription(MedicineId,PrescriptionId) VALUES (8, 6)
  INSERT INTO MedicinePrescription(MedicineId,PrescriptionId) VALUES (9, 7)
  INSERT INTO MedicinePrescription(MedicineId,PrescriptionId) VALUES (10, 7)
  INSERT INTO MedicinePrescription(MedicineId,PrescriptionId) VALUES (11, 8)
  INSERT INTO MedicinePrescription(MedicineId,PrescriptionId) VALUES (12, 9)
  INSERT INTO MedicinePrescription(MedicineId,PrescriptionId) VALUES (13, 10)
  INSERT INTO MedicinePrescription(MedicineId,PrescriptionId) VALUES (14, 10)


