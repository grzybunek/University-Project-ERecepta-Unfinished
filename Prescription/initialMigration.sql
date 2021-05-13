BEGIN TRANSACTION;
GO

CREATE TABLE [Prescription] (
    [Id] int NOT NULL IDENTITY,
    [IdDoctor] int NOT NULL,
    [IdPatient] int NOT NULL,
    [Date] datetime2 NOT NULL,
	[DateOfExpiration] datetime2 NOT NULL,
    CONSTRAINT [PK_Prescription] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Medicine] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [DailyDose] int NOT NULL,
    CONSTRAINT [PK_Medicine] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [MedicinePrescription] (
    [MedicineId] int NOT NULL,
    [PrescriptionId] int NOT NULL,
    CONSTRAINT [PK_MedicinePrescription] PRIMARY KEY ([MedicineId], [PrescriptionId]),
    CONSTRAINT [FK_MedicinePrescription_Medicine_MedicineId] FOREIGN KEY ([MedicineId]) REFERENCES [Medicine] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MedicinePrescription_Prescription_PrescriptionId] FOREIGN KEY ([PrescriptionId]) REFERENCES [Prescription] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_MedicinePrescription_PrescriptionId] ON [MedicinePrescription] ([PrescriptionId]);
GO


COMMIT;
GO