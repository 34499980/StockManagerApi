ALTER TABLE DISPATCH DROP COLUMN IdUserDestiny;

EXEC sp_rename 'DISPATCH.IdUserOrigin', 'IdUser';  