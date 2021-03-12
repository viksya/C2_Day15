CREATE TABLE [dbo].[Movies] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [MovieId]       INT             NOT NULL,
    [Title]         NVARCHAR (100)  NOT NULL,
	[Pic] NVARCHAR (200)  NOT NULL,
    [Description]   NVARCHAR (2000) NOT NULL,
    [AvailableTime] DATETIME        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);