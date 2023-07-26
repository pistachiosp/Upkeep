INSERT INTO UserProfile (FirebaseUserId, Name, Email)
VALUES ('GQR1Wos0dOO6XpckVGMoYL3ifUC2', 'Nick Pushic', 'nick@mail.com');

INSERT INTO Property (UserProfileId, PropertyName, PropertyAddress, PropertyImagUrl)
VALUES (1, 'House 1', '123 Main St', 'http://example.com/image1.jpg'),
(1, 'House 2', '456 Broadway St', NULL);

INSERT INTO UpKeepComponent (Name, UpkeepDetails, PropertyId, Frequency)
VALUES ('Upkeep 1', 'Details for Upkeep 1', 1, 'monthly'),
('Upkeep 2', 'Details for Upkeep 2', 2, 'weekly');

INSERT INTO Caretaker (Name, CaretakerInfo)
VALUES ('Caretaker 1', 'Info for Caretaker 1'),
('Caretaker 2', 'Info for Caretaker 2');

INSERT INTO PropertyCaretaker (PropertyId, CaretakerId)
VALUES (1, 1),
(2, 2);