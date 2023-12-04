
/****** Creates a prepared statement that allows creating users ******/

CREATE OR ALTER PROCEDURE USER_MASTER_CREATE 
	@Guid uniqueidentifier = null,
	@Email nvarchar(255) = null,
	@Password varbinary(max) = null
AS
BEGIN
	SET NOCOUNT ON;

	IF @Guid IS NOT NULL
		IF EXISTS (SELECT 1 FROM [User] WHERE Guid = @Guid)
			UPDATE [User] SET Guid = @Guid, Email = @Email, Password = @Password
		ELSE 
			INSERT INTO [User] (Guid, Email, Password)
				VALUES (@Guid, @Email, @Password)
		ELSE 
			THROW 50001, 'ERROR UPDATING VAULT: SLIPSPACE RUPTURE DETECTED',1
END
GO


/****** Creates a prepared statement that adds login capability ******/

CREATE OR ALTER PROCEDURE USER_MASTER_LOGIN 
	@Email nvarchar(255)= null,
	@Password varbinary(max) = null
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT Guid FROM [User] WHERE Email = @Email AND Password = @Password
END
GO


/****** Creates a prepared statement that gets the salt******/

CREATE OR ALTER PROCEDURE GET_SALT
	@Email nvarchar(255) = null
AS
BEGIN
	SET NOCOUNT ON;

	IF @Email IS NOT NULL
		SELECT U.Password
		FROM [User] U WHERE U.Email = @Email
	ELSE 
		THROW 50001, 'Error fetching user salt',1
END
GO


/****** Creates a prepared statement that adds a file to the db ******/

CREATE OR ALTER PROCEDURE CREATE_FILE 
	@UserGuid uniqueidentifier = null,
	@FileGuid uniqueidentifier = null,
	@File varbinary(max) = null
AS
BEGIN
	SET NOCOUNT ON;

	IF @FileGuid IS NOT NULL
		INSERT INTO [EncryptedFile] (Guid, EncryptedFile)
				VALUES (@FileGuid, @File)
		INSERT INTO [UserFile] (UserGuid, FileGuid)
				VALUES (@UserGuid, @FileGuid)
END
GO


/****** Creates a prepared statement that shares a file to a user ******/

CREATE OR ALTER PROCEDURE CREATE_SHARE 
	@UserGuid uniqueidentifier = null,
	@FileGuid uniqueidentifier = null
AS
BEGIN
	SET NOCOUNT ON;

	IF @FileGuid IS NOT NULL
		INSERT INTO [SharedWith] (UserGuid, FileGuid)
				VALUES (@UserGuid, @FileGuid)
END
GO


/****** Creates a prepared statement that fetches a users file from the db ******/

CREATE OR ALTER PROCEDURE GET_USER_FILES 
	@UserGuid uniqueidentifier = null
AS
BEGIN
	SET NOCOUNT ON;

	IF @UserGuid IS NOT NULL
		SELECT E.EncryptedFile
		FROM EncryptedFile E 
			JOIN [UserFile] UF ON UF.FileGuid = E.Guid
			JOIN [User] U ON U.Guid = UF.Userguid
		WHERE U.Guid = @UserGuid
	ELSE 
		THROW 50001, 'Error fetching file',1
END
GO


/****** Creates a prepared statement that fetches a shared file from the db ******/

CREATE OR ALTER PROCEDURE GET_SHARED_FILES 
	@UserGuid uniqueidentifier = null
AS
BEGIN
	SET NOCOUNT ON;

	IF @UserGuid IS NOT NULL
		SELECT E.EncryptedFile
		FROM EncryptedFile E 
			JOIN [SharedWith] SF ON SF.FileGuid = E.Guid
			JOIN [User] U ON U.Guid = SF.Userguid
		WHERE U.Guid = @UserGuid
	ELSE 
		THROW 50001, 'Error fetching file',1
END
GO