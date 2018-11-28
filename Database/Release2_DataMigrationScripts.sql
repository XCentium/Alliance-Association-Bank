-- Update Active flag on all Non-Inactive projects
UPDATE dbo.Projects
SET Active = 1
WHERE ProjectName NOT LIKE 'INACTIVE -%'
  AND Active = 0

--SELECT * 
--FROM dbo.Projects
--WHERE ProjectName LIKE 'INACTIVE -%'
--  AND Active = 0

-- Update Project names to remove 'INACTIVE -' value (optional step)
--UPDATE dbo.Projects
--SET ProjectName = RTRIM(LTRIM(REPLACE(ProjectName, 'INACTIVE -', ''))),
--    Active = 0
--FROM dbo.Projects
--WHERE ProjectName LIKE 'INACTIVE -%'