-- Populate LockboxNotes field based on 3 existing Note fields
UPDATE p
SET LockboxNotes = 	NULLIF(RTRIM(LTRIM(
								(CASE WHEN NULLIF(RTRIM(LTRIM(ValidationFileNotes)),'') IS NOT NULL 
									 THEN N'**** Validation File Notes ****' + CHAR(13) + RTRIM(LTRIM(ValidationFileNotes)) + CHAR(13) + + CHAR(13) ELSE N'' END +

								CASE WHEN NULLIF(RTRIM(LTRIM(ScannlineNotes)),'') IS NOT NULL 
									 THEN N'**** Scannline Notes ****' + CHAR(13) + RTRIM(LTRIM(ScannlineNotes)) + CHAR(13) + + CHAR(13) ELSE N'' END +

								CASE WHEN NULLIF(RTRIM(LTRIM(CouponPrintingNotes)),'') IS NOT NULL
									 THEN N'**** Coupon Printing Notes ****' + CHAR(13) + RTRIM(LTRIM(CouponPrintingNotes)) + CHAR(13) + + CHAR(13) ELSE N'' END))),'')
FROM [dbo].[Projects] p


-- Update new ACH Web PPD - Debit field based on existing data 
UPDATE p
SET p.ACHWebPPD = 'Debit'
FROM [dbo].[Projects] p
WHERE ConsumerDebitWeb = 1


-- Convert data in Authorization column to 2 new columns
UPDATE u
SET EnrollmentFormAuthorization = CASE WHEN [Authorization] = 'Enrollment Form' THEN 1 ELSE 0 END,
    EmailAuthorization = CASE WHEN [Authorization] = 'eMail' THEN 1 ELSE 0 END
FROM [dbo].[Users] u


-- Update user's StatementEmail flag based on existing StatementEmail email dist list
UPDATE u
SET u.StatementEmail = 1
--SELECT u.ID, u.Email, u.StatementEmail, p.StatementEmail
FROM [AAB_CRM_DB].[dbo].[Users] u 
JOIN [AAB_CRM_DB].[dbo].[Projects] p ON p.ID = u.ProjectID 
WHERE 
	p.StatementEmail like u.Email+';%' OR
	p.StatementEmail like u.Email+' %' OR	
	p.StatementEmail like '%;'+u.Email+';%' OR
	p.StatementEmail like '%;'+u.Email+' %' OR
	p.StatementEmail like '% '+u.Email+';%' OR
	p.StatementEmail like '% '+u.Email+' %' OR	
	p.StatementEmail like '%;'+ u.Email OR
	p.StatementEmail like '% '+ u.Email


-- Update user's LockboxEmail flag based on existing LockboxEmail email dist list
UPDATE u
SET u.LockboxEmail = 1
--SELECT u.ID, u.Email, u.LockboxEmail, p.LockboxEmail
FROM [AAB_CRM_DB].[dbo].[Users] u 
JOIN [AAB_CRM_DB].[dbo].[Projects] p ON p.ID = u.ProjectID 
WHERE 
	p.LockboxEmail like u.Email+';%' OR
	p.LockboxEmail like u.Email+' %' OR	
	p.LockboxEmail like '%;'+u.Email+';%' OR
	p.LockboxEmail like '%;'+u.Email+' %' OR
	p.LockboxEmail like '% '+u.Email+';%' OR
	p.LockboxEmail like '% '+u.Email+' %' OR	
	p.LockboxEmail like '%;'+ u.Email OR
	p.LockboxEmail like '% '+ u.Email


-- Update user's ACHEmail flag based on existing ACHEmail email dist list
UPDATE u
SET u.ACHEmail = 1
--SELECT u.ID, u.Email, u.ACHEmail, p.ACHEmail
FROM [AAB_CRM_DB].[dbo].[Users] u 
JOIN [AAB_CRM_DB].[dbo].[Projects] p ON p.ID = u.ProjectID 
WHERE 
	p.ACHEmail like u.Email+';%' OR
	p.ACHEmail like u.Email+' %' OR	
	p.ACHEmail like '%;'+u.Email+';%' OR
	p.ACHEmail like '%;'+u.Email+' %' OR
	p.ACHEmail like '% '+u.Email+';%' OR
	p.ACHEmail like '% '+u.Email+' %' OR	
	p.ACHEmail like '%;'+ u.Email OR
	p.ACHEmail like '% '+ u.Email


-- Migrate Projects.ReformatAQ2 data to depend on ReformatsAQ2 table as FK
UPDATE p
SET p.ReformatAQ2 = r.ID
FROM [dbo].[Projects] p
JOIN [dbo].[ReformatsAQ2] r ON r.ReformatName = p.ReformatAQ2

ALTER TABLE [dbo].[Projects] ALTER COLUMN ReformatAQ2 INT NULL
exec sp_rename 'Projects.ReformatAQ2', 'ReformatAQ2ID', 'COLUMN';


-- Migrate existing data Notes data to new table
INSERT INTO dbo.Notes (ProjectID, NoteText, DateAdded)
SELECT ID AS ProjectID, Notes AS NoteText, '9/24/2018' AS DateAdded
  FROM [AAB_CRM_DB].[dbo].[Projects]
  Where Notes IS NOT NULL AND RTRIM(LTRIM(Notes)) != ''
    AND ID != 230


/* This is not needed anymore
-- Update Software data columns
--INSERT INTO dbo.Software (SoftwareName)
--SELECT DISTINCT RTRIM(LTRIM(p.SoftwareID)) FROM dbo.Projects p WHERE p.SoftwareID NOT IN (SELECT e.SoftwareName FROM dbo.Software e) ORDER BY 1

--INSERT INTO dbo.Software (SoftwareName)
--SELECT DISTINCT RTRIM(LTRIM(p.MigratingToSoftwareID)) FROM dbo.Projects p WHERE p.MigratingToSoftwareID NOT IN (SELECT e.SoftwareName FROM dbo.Software e) ORDER BY 1

--UPDATE p
--SET p.SoftwareID = s.ID
--FROM dbo.Projects p
--JOIN dbo.Software s ON RTRIM(LTRIM(s.SoftwareName)) = RTRIM(LTRIM(p.SoftwareID))

--UPDATE p
--SET p.MigratingToSoftwareID = s.ID
--FROM dbo.Projects p
--JOIN dbo.Software s ON RTRIM(LTRIM(s.SoftwareName)) = RTRIM(LTRIM(p.MigratingToSoftwareID))

-- This is not needed anymore
--ALTER TABLE dbo.Projects ALTER COLUMN SoftwareID INT
--ALTER TABLE dbo.Projects ALTER COLUMN MigratingToSoftwareID INT
*/

-- This is not needed anymore
/*-- Migrate Projects.ReformatECP data to depend on ReformatsECP table as FK
UPDATE p
SET p.ReformatECP = r.ID
FROM [dbo].[Projects] p
JOIN [dbo].[ReformatsECP] r ON r.ReformatName = p.ReformatECP

ALTER TABLE [dbo].[Projects] ALTER COLUMN ReformatECP INT NULL
exec sp_rename 'Projects.ReformatECP', 'ReformatECPID', 'COLUMN';*/