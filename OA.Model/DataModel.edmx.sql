
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/13/2019 13:44:32
-- Generated from EDMX file: F:\VSWorkSpace\WebTest1\OA\OA.Model\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [OA];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_R_UserInfo_ActionInfoActionInfo_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_UserInfo_ActionInfoActionInfo] DROP CONSTRAINT [FK_R_UserInfo_ActionInfoActionInfo_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_R_UserInfo_ActionInfoActionInfo_R_UserInfo_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_UserInfo_ActionInfoActionInfo] DROP CONSTRAINT [FK_R_UserInfo_ActionInfoActionInfo_R_UserInfo_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleInfoActionInfo_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleInfoActionInfo] DROP CONSTRAINT [FK_RoleInfoActionInfo_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleInfoActionInfo_RoleInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleInfoActionInfo] DROP CONSTRAINT [FK_RoleInfoActionInfo_RoleInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoOrderInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderInfo] DROP CONSTRAINT [FK_UserInfoOrderInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoR_UserInfo_ActionInfo_R_UserInfo_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoR_UserInfo_ActionInfo] DROP CONSTRAINT [FK_UserInfoR_UserInfo_ActionInfo_R_UserInfo_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoR_UserInfo_ActionInfo_UserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoR_UserInfo_ActionInfo] DROP CONSTRAINT [FK_UserInfoR_UserInfo_ActionInfo_UserInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoRoleInfo_RoleInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoRoleInfo] DROP CONSTRAINT [FK_UserInfoRoleInfo_RoleInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoRoleInfo_UserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoRoleInfo] DROP CONSTRAINT [FK_UserInfoRoleInfo_UserInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_WF_InstanceFileInfo_FileInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WF_InstanceFileInfo] DROP CONSTRAINT [FK_WF_InstanceFileInfo_FileInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_WF_InstanceFileInfo_WF_Instance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WF_InstanceFileInfo] DROP CONSTRAINT [FK_WF_InstanceFileInfo_WF_Instance];
GO
IF OBJECT_ID(N'[dbo].[FK_WF_InstanceWF_Step]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WF_Step] DROP CONSTRAINT [FK_WF_InstanceWF_Step];
GO
IF OBJECT_ID(N'[dbo].[FK_WF_TempWF_Instance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WF_Instance] DROP CONSTRAINT [FK_WF_TempWF_Instance];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FileInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FileInfo];
GO
IF OBJECT_ID(N'[dbo].[OrderInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderInfo];
GO
IF OBJECT_ID(N'[dbo].[R_UserInfo_ActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_UserInfo_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[R_UserInfo_ActionInfoActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_UserInfo_ActionInfoActionInfo];
GO
IF OBJECT_ID(N'[dbo].[RoleInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleInfo];
GO
IF OBJECT_ID(N'[dbo].[RoleInfoActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleInfoActionInfo];
GO
IF OBJECT_ID(N'[dbo].[UserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfo];
GO
IF OBJECT_ID(N'[dbo].[UserInfoEXt]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoEXt];
GO
IF OBJECT_ID(N'[dbo].[UserInfoR_UserInfo_ActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoR_UserInfo_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[UserInfoRoleInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoRoleInfo];
GO
IF OBJECT_ID(N'[dbo].[WF_Instance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WF_Instance];
GO
IF OBJECT_ID(N'[dbo].[WF_InstanceFileInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WF_InstanceFileInfo];
GO
IF OBJECT_ID(N'[dbo].[WF_Step]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WF_Step];
GO
IF OBJECT_ID(N'[dbo].[WF_Temp]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WF_Temp];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ActionInfo'
CREATE TABLE [dbo].[ActionInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RoleInfoID] int  NOT NULL,
    [DelFlag] int  NOT NULL,
    [Remark] nvarchar(500)  NULL,
    [ModifiedOn] int  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [URL] nvarchar(max)  NOT NULL,
    [HttpMethod] nvarchar(max)  NOT NULL,
    [ActionName] nvarchar(30)  NOT NULL,
    [IsMenu] bit  NOT NULL,
    [MenuIcon] nvarchar(300)  NULL,
    [Sort] nvarchar(20)  NULL
);
GO

-- Creating table 'OrderInfo'
CREATE TABLE [dbo].[OrderInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(500)  NULL,
    [UserInfoID] int  NOT NULL
);
GO

-- Creating table 'R_UserInfo_ActionInfo'
CREATE TABLE [dbo].[R_UserInfo_ActionInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Remark] nvarchar(500)  NULL,
    [DelFlag] int  NOT NULL,
    [ModifiedOn] int  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [UserInfoID] int  NOT NULL,
    [ActionInfoID] int  NULL,
    [HasPermission] bit  NOT NULL
);
GO

-- Creating table 'RoleInfo'
CREATE TABLE [dbo].[RoleInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Remark] nvarchar(500)  NULL,
    [DelFlag] int  NOT NULL,
    [ModifiedOn] int  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [UserInfoID] int  NULL,
    [RoleName] nvarchar(30)  NOT NULL,
    [ActionInfoID] int  NULL
);
GO

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UName] nvarchar(32)  NOT NULL,
    [Pwd] nvarchar(32)  NOT NULL,
    [ShowName] nvarchar(32)  NOT NULL,
    [DelFlag] int  NOT NULL,
    [Remark] nvarchar(500)  NULL,
    [ModifiedOn] int  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [Email] nvarchar(50)  NULL
);
GO

-- Creating table 'UserInfoEXt'
CREATE TABLE [dbo].[UserInfoEXt] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserInfoID] int  NOT NULL,
    [Age] int  NOT NULL,
    [DelFlag] int  NOT NULL,
    [Remark] nvarchar(500)  NULL,
    [ModifiedOn] int  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [Phone] int  NOT NULL,
    [Email] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'WF_Temp'
CREATE TABLE [dbo].[WF_Temp] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TempName] nvarchar(32)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [TempForm] nvarchar(max)  NULL,
    [SubTime] datetime  NULL,
    [Remark] nvarchar(500)  NULL,
    [DelFlag] int  NOT NULL,
    [ActivityType] nvarchar(max)  NULL
);
GO

-- Creating table 'WF_Instance'
CREATE TABLE [dbo].[WF_Instance] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [InstanceName] nvarchar(32)  NOT NULL,
    [StartBy] nvarchar(32)  NULL,
    [StartTime] datetime  NULL,
    [Level] smallint  NULL,
    [Content] nvarchar(max)  NULL,
    [Remark] nvarchar(500)  NULL,
    [DelFlag] int  NOT NULL,
    [WFInstanceID] nvarchar(max)  NOT NULL,
    [WF_TempID] int  NOT NULL,
    [Status] int  NULL
);
GO

-- Creating table 'FileInfo'
CREATE TABLE [dbo].[FileInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FileName] nvarchar(32)  NOT NULL,
    [FileType] nvarchar(32)  NULL,
    [FilePath] nvarchar(32)  NULL,
    [FileSize] nvarchar(32)  NULL,
    [SubTime] datetime  NULL,
    [Remark] nvarchar(500)  NULL,
    [DelFlag] int  NOT NULL
);
GO

-- Creating table 'WF_Step'
CREATE TABLE [dbo].[WF_Step] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [StepName] nvarchar(32)  NOT NULL,
    [ProcessBy] nvarchar(32)  NOT NULL,
    [ProcessTime] datetime  NOT NULL,
    [ProcessResult] nvarchar(200)  NOT NULL,
    [ProcessComment] nvarchar(200)  NOT NULL,
    [StepStatus] nvarchar(32)  NOT NULL,
    [IsStartStep] bit  NOT NULL,
    [IsEndStep] bit  NOT NULL,
    [WF_InstanceID] int  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [ParentStepID] int  NOT NULL
);
GO

-- Creating table 'R_UserInfo_ActionInfoActionInfo'
CREATE TABLE [dbo].[R_UserInfo_ActionInfoActionInfo] (
    [ActionInfo_ID] int  NOT NULL,
    [R_UserInfo_ActionInfo_ID] int  NOT NULL
);
GO

-- Creating table 'RoleInfoActionInfo'
CREATE TABLE [dbo].[RoleInfoActionInfo] (
    [ActionInfo_ID] int  NOT NULL,
    [RoleInfo_ID] int  NOT NULL
);
GO

-- Creating table 'UserInfoR_UserInfo_ActionInfo'
CREATE TABLE [dbo].[UserInfoR_UserInfo_ActionInfo] (
    [R_UserInfo_ActionInfo_ID] int  NOT NULL,
    [UserInfo_ID] int  NOT NULL
);
GO

-- Creating table 'UserInfoRoleInfo'
CREATE TABLE [dbo].[UserInfoRoleInfo] (
    [RoleInfo_ID] int  NOT NULL,
    [UserInfo_ID] int  NOT NULL
);
GO

-- Creating table 'WF_InstanceFileInfo'
CREATE TABLE [dbo].[WF_InstanceFileInfo] (
    [WF_Instance_ID] int  NOT NULL,
    [FileInfo_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'ActionInfo'
ALTER TABLE [dbo].[ActionInfo]
ADD CONSTRAINT [PK_ActionInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'OrderInfo'
ALTER TABLE [dbo].[OrderInfo]
ADD CONSTRAINT [PK_OrderInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'R_UserInfo_ActionInfo'
ALTER TABLE [dbo].[R_UserInfo_ActionInfo]
ADD CONSTRAINT [PK_R_UserInfo_ActionInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'RoleInfo'
ALTER TABLE [dbo].[RoleInfo]
ADD CONSTRAINT [PK_RoleInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserInfoEXt'
ALTER TABLE [dbo].[UserInfoEXt]
ADD CONSTRAINT [PK_UserInfoEXt]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WF_Temp'
ALTER TABLE [dbo].[WF_Temp]
ADD CONSTRAINT [PK_WF_Temp]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WF_Instance'
ALTER TABLE [dbo].[WF_Instance]
ADD CONSTRAINT [PK_WF_Instance]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FileInfo'
ALTER TABLE [dbo].[FileInfo]
ADD CONSTRAINT [PK_FileInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WF_Step'
ALTER TABLE [dbo].[WF_Step]
ADD CONSTRAINT [PK_WF_Step]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ActionInfo_ID], [R_UserInfo_ActionInfo_ID] in table 'R_UserInfo_ActionInfoActionInfo'
ALTER TABLE [dbo].[R_UserInfo_ActionInfoActionInfo]
ADD CONSTRAINT [PK_R_UserInfo_ActionInfoActionInfo]
    PRIMARY KEY CLUSTERED ([ActionInfo_ID], [R_UserInfo_ActionInfo_ID] ASC);
GO

-- Creating primary key on [ActionInfo_ID], [RoleInfo_ID] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [PK_RoleInfoActionInfo]
    PRIMARY KEY CLUSTERED ([ActionInfo_ID], [RoleInfo_ID] ASC);
GO

-- Creating primary key on [R_UserInfo_ActionInfo_ID], [UserInfo_ID] in table 'UserInfoR_UserInfo_ActionInfo'
ALTER TABLE [dbo].[UserInfoR_UserInfo_ActionInfo]
ADD CONSTRAINT [PK_UserInfoR_UserInfo_ActionInfo]
    PRIMARY KEY CLUSTERED ([R_UserInfo_ActionInfo_ID], [UserInfo_ID] ASC);
GO

-- Creating primary key on [RoleInfo_ID], [UserInfo_ID] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [PK_UserInfoRoleInfo]
    PRIMARY KEY CLUSTERED ([RoleInfo_ID], [UserInfo_ID] ASC);
GO

-- Creating primary key on [WF_Instance_ID], [FileInfo_ID] in table 'WF_InstanceFileInfo'
ALTER TABLE [dbo].[WF_InstanceFileInfo]
ADD CONSTRAINT [PK_WF_InstanceFileInfo]
    PRIMARY KEY CLUSTERED ([WF_Instance_ID], [FileInfo_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserInfoID] in table 'OrderInfo'
ALTER TABLE [dbo].[OrderInfo]
ADD CONSTRAINT [FK_UserInfoOrderInfo]
    FOREIGN KEY ([UserInfoID])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoOrderInfo'
CREATE INDEX [IX_FK_UserInfoOrderInfo]
ON [dbo].[OrderInfo]
    ([UserInfoID]);
GO

-- Creating foreign key on [ActionInfo_ID] in table 'R_UserInfo_ActionInfoActionInfo'
ALTER TABLE [dbo].[R_UserInfo_ActionInfoActionInfo]
ADD CONSTRAINT [FK_R_UserInfo_ActionInfoActionInfo_ActionInfo]
    FOREIGN KEY ([ActionInfo_ID])
    REFERENCES [dbo].[ActionInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [R_UserInfo_ActionInfo_ID] in table 'R_UserInfo_ActionInfoActionInfo'
ALTER TABLE [dbo].[R_UserInfo_ActionInfoActionInfo]
ADD CONSTRAINT [FK_R_UserInfo_ActionInfoActionInfo_R_UserInfo_ActionInfo]
    FOREIGN KEY ([R_UserInfo_ActionInfo_ID])
    REFERENCES [dbo].[R_UserInfo_ActionInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_R_UserInfo_ActionInfoActionInfo_R_UserInfo_ActionInfo'
CREATE INDEX [IX_FK_R_UserInfo_ActionInfoActionInfo_R_UserInfo_ActionInfo]
ON [dbo].[R_UserInfo_ActionInfoActionInfo]
    ([R_UserInfo_ActionInfo_ID]);
GO

-- Creating foreign key on [ActionInfo_ID] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [FK_RoleInfoActionInfo_ActionInfo]
    FOREIGN KEY ([ActionInfo_ID])
    REFERENCES [dbo].[ActionInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RoleInfo_ID] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [FK_RoleInfoActionInfo_RoleInfo]
    FOREIGN KEY ([RoleInfo_ID])
    REFERENCES [dbo].[RoleInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleInfoActionInfo_RoleInfo'
CREATE INDEX [IX_FK_RoleInfoActionInfo_RoleInfo]
ON [dbo].[RoleInfoActionInfo]
    ([RoleInfo_ID]);
GO

-- Creating foreign key on [R_UserInfo_ActionInfo_ID] in table 'UserInfoR_UserInfo_ActionInfo'
ALTER TABLE [dbo].[UserInfoR_UserInfo_ActionInfo]
ADD CONSTRAINT [FK_UserInfoR_UserInfo_ActionInfo_R_UserInfo_ActionInfo]
    FOREIGN KEY ([R_UserInfo_ActionInfo_ID])
    REFERENCES [dbo].[R_UserInfo_ActionInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserInfo_ID] in table 'UserInfoR_UserInfo_ActionInfo'
ALTER TABLE [dbo].[UserInfoR_UserInfo_ActionInfo]
ADD CONSTRAINT [FK_UserInfoR_UserInfo_ActionInfo_UserInfo]
    FOREIGN KEY ([UserInfo_ID])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoR_UserInfo_ActionInfo_UserInfo'
CREATE INDEX [IX_FK_UserInfoR_UserInfo_ActionInfo_UserInfo]
ON [dbo].[UserInfoR_UserInfo_ActionInfo]
    ([UserInfo_ID]);
GO

-- Creating foreign key on [RoleInfo_ID] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [FK_UserInfoRoleInfo_RoleInfo]
    FOREIGN KEY ([RoleInfo_ID])
    REFERENCES [dbo].[RoleInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserInfo_ID] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [FK_UserInfoRoleInfo_UserInfo]
    FOREIGN KEY ([UserInfo_ID])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoRoleInfo_UserInfo'
CREATE INDEX [IX_FK_UserInfoRoleInfo_UserInfo]
ON [dbo].[UserInfoRoleInfo]
    ([UserInfo_ID]);
GO

-- Creating foreign key on [WF_Instance_ID] in table 'WF_InstanceFileInfo'
ALTER TABLE [dbo].[WF_InstanceFileInfo]
ADD CONSTRAINT [FK_WF_InstanceFileInfo_WF_Instance]
    FOREIGN KEY ([WF_Instance_ID])
    REFERENCES [dbo].[WF_Instance]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [FileInfo_ID] in table 'WF_InstanceFileInfo'
ALTER TABLE [dbo].[WF_InstanceFileInfo]
ADD CONSTRAINT [FK_WF_InstanceFileInfo_FileInfo]
    FOREIGN KEY ([FileInfo_ID])
    REFERENCES [dbo].[FileInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WF_InstanceFileInfo_FileInfo'
CREATE INDEX [IX_FK_WF_InstanceFileInfo_FileInfo]
ON [dbo].[WF_InstanceFileInfo]
    ([FileInfo_ID]);
GO

-- Creating foreign key on [WF_TempID] in table 'WF_Instance'
ALTER TABLE [dbo].[WF_Instance]
ADD CONSTRAINT [FK_WF_TempWF_Instance]
    FOREIGN KEY ([WF_TempID])
    REFERENCES [dbo].[WF_Temp]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WF_TempWF_Instance'
CREATE INDEX [IX_FK_WF_TempWF_Instance]
ON [dbo].[WF_Instance]
    ([WF_TempID]);
GO

-- Creating foreign key on [WF_InstanceID] in table 'WF_Step'
ALTER TABLE [dbo].[WF_Step]
ADD CONSTRAINT [FK_WF_InstanceWF_Step]
    FOREIGN KEY ([WF_InstanceID])
    REFERENCES [dbo].[WF_Instance]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WF_InstanceWF_Step'
CREATE INDEX [IX_FK_WF_InstanceWF_Step]
ON [dbo].[WF_Step]
    ([WF_InstanceID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------