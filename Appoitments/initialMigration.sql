BEGIN TRANSACTION;
GO

CREATE TABLE [Places] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Street] nvarchar(max) NOT NULL,
    [HouseNumber] nvarchar(max) NOT NULL,
    [Town] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Places] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Appointments] (
    [Id] int NOT NULL IDENTITY,
    [IdDoctor] int NOT NULL,
    [IdPatient] int NOT NULL,
    [StartDateOfTheVisit] datetime2 NOT NULL,
    [EndDateOfTheVisit] datetime2 NOT NULL,
    CONSTRAINT [PK_Appointments] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AppointmentPlace] (
    [AppointmentId] int NOT NULL,
    [PlaceId] int NOT NULL,
    CONSTRAINT [PK_AppointmentPlace] PRIMARY KEY ([AppointmentId], [PlaceId]),
    CONSTRAINT [FK_AppointmentPlace_Appointments_AppointmentId] FOREIGN KEY ([AppointmentId]) REFERENCES [Appointments] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AppointmentPlace_Places_PlaceId] FOREIGN KEY ([PlaceId]) REFERENCES [Places] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_AppointmentPlace_AppointmentId] ON [AppointmentPlace] ([AppointmentId]);
GO


COMMIT;
GO




