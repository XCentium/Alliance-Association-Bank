-- Update Active flag on all Non-Inactive projects
UPDATE dbo.Projects
SET Active = 1
WHERE ProjectName NOT LIKE 'INACTIVE%'

--SELECT * 
--FROM dbo.Projects
--WHERE ProjectName NOT LIKE 'INACTIVE%'
--  AND Active = 0
--  /*AND ProjectName LIKE '%INACTIVE%'*/