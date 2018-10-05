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