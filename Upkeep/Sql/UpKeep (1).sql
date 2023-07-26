CREATE TABLE [UserProfile] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [FirebaseUserId] nvarchar(255) NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Email] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Property] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [UserProfileId] int NOT NULL,
  [PropertyName] nvarchar(255) NOT NULL,
  [propertyAddress] nvarchar(255) NOT NULL,
  [PropertyImagUrl] nvarchar(255)
  )
  GO
CREATE TABLE [UpKeepComponent] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL,
  [UpkeepDetails] nvarchar(255) NOT NULL,
  [PropertyId] int NOT NULL,
  [Frequency] nvarchar(255) NOT NULL,
)
GO

CREATE TABLE [Caretaker] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL,
  [CaretakerInfo] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [PropertyCaretaker] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [PropertyId] int NOT NULL,
  [CaretakerId] int NOT NULL
)
GO

ALTER TABLE [PropertyCaretaker] ADD FOREIGN KEY ([CaretakerId]) REFERENCES [Caretaker] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [UpKeepComponent] ADD FOREIGN KEY ([PropertyId]) REFERENCES [Property] ([id]) ON DELETE CASCADE
GO

ALTER TABLE [Property] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([id]) ON DELETE CASCADE
GO

ALTER TABLE [PropertyCaretaker] ADD FOREIGN KEY ([PropertyId]) REFERENCES [Property] ([id]) ON DELETE CASCADE
GO
