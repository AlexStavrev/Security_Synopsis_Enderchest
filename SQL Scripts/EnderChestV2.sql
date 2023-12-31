USE [EnderChest]
GO
/****** Object:  Table [dbo].[EncryptedFile]    Script Date: 20-12-2023 11:24:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EncryptedFile](
	[Guid] [uniqueidentifier] NOT NULL,
	[EncryptedFile] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_EncryptedFile] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SharedFile]    Script Date: 20-12-2023 11:24:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SharedFile](
	[Guid] [uniqueidentifier] NOT NULL,
	[EncryptedFile] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_SharedFile] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SharedFolder]    Script Date: 20-12-2023 11:24:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SharedFolder](
	[Guid] [uniqueidentifier] NOT NULL,
	[OwnerGuid] [uniqueidentifier] NOT NULL,
	[ShareCode] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_SharedFolder] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SharedFolderFiles]    Script Date: 20-12-2023 11:24:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SharedFolderFiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FolderGuid] [uniqueidentifier] NOT NULL,
	[SharedFileGuid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_SharedFolderFiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SharedWith]    Script Date: 20-12-2023 11:24:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SharedWith](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserGuid] [uniqueidentifier] NOT NULL,
	[SharedFolderGuid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_SharedWith] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 20-12-2023 11:24:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Guid] [uniqueidentifier] NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Password] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserFile]    Script Date: 20-12-2023 11:24:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserGuid] [uniqueidentifier] NOT NULL,
	[FileGuid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UserFile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SharedFolder]  WITH CHECK ADD  CONSTRAINT [FK_SharedFolder_User] FOREIGN KEY([OwnerGuid])
REFERENCES [dbo].[User] ([Guid])
GO
ALTER TABLE [dbo].[SharedFolder] CHECK CONSTRAINT [FK_SharedFolder_User]
GO
ALTER TABLE [dbo].[SharedFolderFiles]  WITH CHECK ADD  CONSTRAINT [FK_SharedFolderFiles_SharedFile] FOREIGN KEY([SharedFileGuid])
REFERENCES [dbo].[SharedFile] ([Guid])
GO
ALTER TABLE [dbo].[SharedFolderFiles] CHECK CONSTRAINT [FK_SharedFolderFiles_SharedFile]
GO
ALTER TABLE [dbo].[SharedFolderFiles]  WITH CHECK ADD  CONSTRAINT [FK_SharedFolderFiles_SharedFolder1] FOREIGN KEY([FolderGuid])
REFERENCES [dbo].[SharedFolder] ([Guid])
GO
ALTER TABLE [dbo].[SharedFolderFiles] CHECK CONSTRAINT [FK_SharedFolderFiles_SharedFolder1]
GO
ALTER TABLE [dbo].[SharedWith]  WITH CHECK ADD  CONSTRAINT [FK_SharedWith_SharedFolder] FOREIGN KEY([SharedFolderGuid])
REFERENCES [dbo].[SharedFolder] ([Guid])
GO
ALTER TABLE [dbo].[SharedWith] CHECK CONSTRAINT [FK_SharedWith_SharedFolder]
GO
ALTER TABLE [dbo].[SharedWith]  WITH CHECK ADD  CONSTRAINT [FK_SharedWith_User] FOREIGN KEY([UserGuid])
REFERENCES [dbo].[User] ([Guid])
GO
ALTER TABLE [dbo].[SharedWith] CHECK CONSTRAINT [FK_SharedWith_User]
GO
ALTER TABLE [dbo].[UserFile]  WITH CHECK ADD  CONSTRAINT [FK_UserFile_EncryptedFile] FOREIGN KEY([FileGuid])
REFERENCES [dbo].[EncryptedFile] ([Guid])
GO
ALTER TABLE [dbo].[UserFile] CHECK CONSTRAINT [FK_UserFile_EncryptedFile]
GO
ALTER TABLE [dbo].[UserFile]  WITH CHECK ADD  CONSTRAINT [FK_UserFile_User] FOREIGN KEY([UserGuid])
REFERENCES [dbo].[User] ([Guid])
GO
ALTER TABLE [dbo].[UserFile] CHECK CONSTRAINT [FK_UserFile_User]
GO
