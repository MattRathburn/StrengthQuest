USE StrengthQuestDev
GO

/*
 *   To use this you must register a user first
 */

DECLARE @UId nvarchar(256);

select Top(1) @UId = id from AspNetUsers

DECLARE @LiftNameId1 nvarchar(256);
DECLARE @LiftNameId2 nvarchar(256);
DECLARE @LiftNameId3 nvarchar(256);
DECLARE @LiftNameId4 nvarchar(256);

DECLARE @LiftTypeId1 nvarchar(256);
DECLARE @LiftTypeId2 nvarchar(256);
DECLARE @LiftTypeId3 nvarchar(256);

DECLARE @LiftId1 nvarchar(256);
DECLARE @LiftId2 nvarchar(256);
DECLARE @LiftId3 nvarchar(256);
DECLARE @LiftId4 nvarchar(256);

SET @LiftNameId1 = NEWID();
SET @LiftNameId2 = NEWID();
SET @LiftNameId3 = NEWID();
SET @LiftNameId4 = NEWID();

SET @LiftTypeId1 = NEWID();
SET @LiftTypeId2 = NEWID();
SET @LiftTypeId3 = NEWID();

SET @LiftId1 = NEWID();
SET @LiftId2 = NEWID();
SET @LiftId3 = NEWID();
SET @LiftId4 = NEWID();

INSERT INTO dbo.LiftNames VALUES (@LiftNameId1, 'Bench Press')
INSERT INTO dbo.LiftNames VALUES (@LiftNameId2, 'Overhead Press')
INSERT INTO dbo.LiftNames VALUES (@LiftNameId3, 'Squat')
INSERT INTO dbo.LiftNames VALUES (@LiftNameId4, 'Bent Over Row')

INSERT INTO dbo.WeightMetrics VALUES (NEWID(), 1, @UId)

INSERT INTO dbo.LiftTypes VALUES (@LiftTypeId1, 'Lower')
INSERT INTO dbo.LiftTypes VALUES (@LiftTypeId2, 'Push')
INSERT INTO dbo.LiftTypes VALUES (@LiftTypeId3, 'Pull')

INSERT INTO Lifts VALUES (@LiftId1, 200, 1, GETDATE(), @UId, @LiftNameId3, @LiftTypeId1, 2)
INSERT INTO Lifts VALUES (@LiftId2, 200, 1, GETDATE(), @UId, @LiftNameId2, @LiftTypeId2, 2)
INSERT INTO Lifts VALUES (@LiftId3, 200, 1, GETDATE(), @UId, @LiftNameId1, @LiftTypeId2, 2)
INSERT INTO Lifts VALUES (@LiftId4, 200, 1, GETDATE(), @UId, @LiftNameId4, @LiftTypeId3, 2)

INSERT INTO LiftSequences VALUES (NEWID(), 1, @UId, @LiftId1)
INSERT INTO LiftSequences VALUES (NEWID(), 1, @UId, @LiftId2)
INSERT INTO LiftSequences VALUES (NEWID(), 1, @UId, @LiftId3)
INSERT INTO LiftSequences VALUES (NEWID(), 1, @UId, @LiftId4)
