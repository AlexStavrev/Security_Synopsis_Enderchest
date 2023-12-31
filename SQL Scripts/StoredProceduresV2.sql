USE [EnderChest]
GO
/****** Object:  StoredProcedure [dbo].[ADD_FILE_TO_SHARED_FOLDER]    Script Date: 20-12-2023 13:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[ADD_FILE_TO_SHARED_FOLDER] 
	-- Add the parameters for the stored procedure here
	@FolderGuid uniqueidentifier = null,
	@FileGuid uniqueidentifier = null,
	@EncryptedFile varbinary(max) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [SharedFile] ([Guid], EncryptedFile)
				VALUES (@FileGuid, @EncryptedFile)
	INSERT INTO [SharedFolderFiles] (FolderGuid, SharedFileGuid)
				VALUES (@FolderGuid, @FileGuid)
		
END
GO
/****** Object:  StoredProcedure [dbo].[CREATE_FILE]    Script Date: 20-12-2023 13:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[CREATE_FILE] 
	-- Add the parameters for the stored procedure here
	@UserGuid uniqueidentifier = null,
	@FileGuid uniqueidentifier = null,
	@File varbinary(max) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @FileGuid IS NOT NULL
		INSERT INTO [EncryptedFile] (Guid, EncryptedFile)
				VALUES (@FileGuid, @File)
		INSERT INTO [UserFile] (UserGuid, FileGuid)
				VALUES (@UserGuid, @FileGuid)
	
END
GO
/****** Object:  StoredProcedure [dbo].[CREATE_SHARE]    Script Date: 20-12-2023 13:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[CREATE_SHARE] 
	-- Add the parameters for the stored procedure here
	@UserGuid uniqueidentifier = null,
	@FileGuid uniqueidentifier = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @FileGuid IS NOT NULL
		INSERT INTO [SharedWith] (UserGuid, SharedFolderGuid)
				VALUES (@UserGuid, @FileGuid)
	
END
GO
/****** Object:  StoredProcedure [dbo].[CREATE_SHARE_FOLDER]    Script Date: 20-12-2023 13:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[CREATE_SHARE_FOLDER] 
	-- Add the parameters for the stored procedure here
	@UserGuid uniqueidentifier = null,
	@OwnerGuid uniqueidentifier = null,
	@ShareFolderGuid uniqueidentifier = null,
	@ShareCode varbinary(max) = null

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @OwnerGuid IS NOT NULL
		INSERT INTO [SharedFolder] (Guid, OwnerGuid, ShareCode)
				VALUES (@ShareFolderGuid, @OwnerGuid, @ShareCode)
		INSERT INTO [SharedWith] (SharedFolderGuid, UserGuid)
				VALUES (@ShareFolderGuid,@UserGuid)
END
GO
/****** Object:  StoredProcedure [dbo].[GET_SALT]    Script Date: 20-12-2023 13:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[GET_SALT]
	-- Add the parameters for the stored procedure here
	@Email nvarchar(255) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @Email IS NOT NULL
		SELECT U.Password
		FROM [User] U WHERE U.Email = @Email
	ELSE 
		THROW 50001, 'Error fetching user salt',1
END
GO
/****** Object:  StoredProcedure [dbo].[GET_USERID]    Script Date: 20-12-2023 13:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[GET_USERID]
	-- Add the parameters for the stored procedure here
	@Email nvarchar(255) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @Email IS NOT NULL
		SELECT U.Guid
		FROM [User] U WHERE U.Email = @Email
	ELSE 
		THROW 50001, 'Error fetching user salt',1
END
GO
/****** Object:  StoredProcedure [dbo].[GET_SALT_SHARED_FOLDER]    Script Date: 20-12-2023 13:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[GET_SALT_SHARED_FOLDER] 
	-- Add the parameters for the stored procedure here
	@ShareFolderGuid varbinary(MAX) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IF @ShareFolderGuid IS NOT NULL
		SELECT S.ShareCode
		FROM [SharedFolder] S WHERE S.Guid = @ShareFolderGuid
	ELSE 
		THROW 50001, 'Error fetching share solder salt',1
END
GO
/****** Object:  StoredProcedure [dbo].[GET_SHARED_FILES]    Script Date: 20-12-2023 13:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[GET_SHARED_FILES] 
	-- Add the parameters for the stored procedure here
	@UserGuid uniqueidentifier = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @UserGuid IS NOT NULL
		SELECT E.EncryptedFile, E.Guid
		FROM EncryptedFile E 
			JOIN [SharedWith] SF ON SF.SharedFolderGuid = E.Guid
			JOIN [User] U ON U.Guid = SF.Userguid
		WHERE U.Guid = @UserGuid
	ELSE 
		THROW 50001, 'Error fetching file',1
END
GO
/****** Object:  StoredProcedure [dbo].[GET_SHARED_FOLDER]    Script Date: 20-12-2023 13:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[GET_SHARED_FOLDER]
	-- Add the parameters for the stored procedure here
	@FolderGuid uniqueidentifier = null,
	@ShareCode varbinary(max) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT F.EncryptedFile, F.Guid FROM [SharedFile] F
	JOIN [SharedFolderFiles] SFF ON SFF.SharedFileGuid = F.Guid
	JOIN [SharedFolder] SF ON SF.Guid = SFF.FolderGuid
	WHERE SF.ShareCode = @ShareCode AND SFF.FolderGuid = @FolderGuid
END
GO
/****** Object:  StoredProcedure [dbo].[GET_SHARED_FOLDER_GUIDS]    Script Date: 20-12-2023 13:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[GET_SHARED_FOLDER_GUIDS] 
	-- Add the parameters for the stored procedure here
	@UserGuid uniqueidentifier = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @UserGuid IS NOT NULL
		SELECT S.SharedFolderGuid
		FROM [SharedWith] S WHERE S.UserGuid = @UserGuid
	ELSE 
		THROW 50001, 'Error fetching folders',1
END
GO
/****** Object:  StoredProcedure [dbo].[GET_USER_FILES]    Script Date: 20-12-2023 13:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[GET_USER_FILES] 
	-- Add the parameters for the stored procedure here
	@UserGuid uniqueidentifier = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @UserGuid IS NOT NULL
		SELECT E.EncryptedFile, E.Guid
		FROM EncryptedFile E 
			JOIN [UserFile] UF ON UF.FileGuid = E.Guid
			JOIN [User] U ON U.Guid = UF.Userguid
		WHERE U.Guid = @UserGuid
	ELSE 
		THROW 50001, 'Error fetching file',1
END
GO
/****** Object:  StoredProcedure [dbo].[USER_MASTER_CREATE]    Script Date: 20-12-2023 13:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[USER_MASTER_CREATE] 
	-- Add the parameters for the stored procedure here
	@Guid uniqueidentifier = null,
	@Email nvarchar(255) = null,
	@Password varbinary(max) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
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
/****** Object:  StoredProcedure [dbo].[USER_MASTER_LOGIN]    Script Date: 20-12-2023 13:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[USER_MASTER_LOGIN] 
	-- Add the parameters for the stored procedure here
	@Email nvarchar(255)= null,
	@Password varbinary(max) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    -- Insert statements for procedure here
	SELECT Guid FROM [User] WHERE Email = @Email AND Password = @Password

END
GO
/****** Object:  StoredProcedure [dbo].[GET_EMAIL]    Script Date: 25/12/2023 13:29:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[GET_EMAIL]
	-- Add the parameters for the stored procedure here
	@Guid uniqueidentifier = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @Guid IS NOT NULL
		SELECT U.Email
		FROM [User] U WHERE U.Guid = @Guid
	ELSE 
		THROW 50001, 'Error fetching user salt',1
END
