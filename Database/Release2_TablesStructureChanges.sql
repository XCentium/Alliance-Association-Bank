ALTER TABLE [dbo].[Projects] ADD Active BIT NOT NULL CONSTRAINT DF_Projects_Active DEFAULT (0)