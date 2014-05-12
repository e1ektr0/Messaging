CREATE TABLE [messaging].[Messages] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [UserId]         NVARCHAR (128) NOT NULL,
    [Subject]        NVARCHAR (MAX) NOT NULL,
    [Text]           NVARCHAR (MAX) NOT NULL,
    [SendDate]       DATETIME       NOT NULL,
    [DeleteSender]   BIT            NOT NULL,
    [DeleteReceiver] BIT            NOT NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Message_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_Message_AspNetUsers]
    ON [messaging].[Messages]([UserId] ASC);

