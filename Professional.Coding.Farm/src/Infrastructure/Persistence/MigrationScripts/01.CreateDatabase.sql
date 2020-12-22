--CREATE DATABASE

create table TodoLists(
						Id [int] NOT NULL IDENTITY(1,1),
						Title nvarchar(500) NOT NULL,
						Colour nvarchar(1),
						IsEnabled bit NOT NULL,
						Version timestamp NOT NULL,
						PRIMARY KEY CLUSTERED 
							(
								Id ASC
							)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
							) ON [PRIMARY];

create table TodoItems(
						Id [int] NOT NULL IDENTITY(1,1),
						TodoListId INT NOT NULL,
						Title nvarchar(500) NOT NULL,
						Note nvarchar(1000) NULL,
						IsDone bit NOT NULL,
						IsEnabled bit NOT NULL,
						PRIMARY KEY CLUSTERED 
							(
								Id ASC
							)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
							) ON [PRIMARY];

ALTER TABLE [dbo].TodoItems  WITH CHECK ADD  CONSTRAINT [FK_TodoItems_TodoLists] FOREIGN KEY(TodoListId)
REFERENCES [dbo].TodoLists ([ID])
GO

ALTER TABLE [dbo].TodoItems CHECK CONSTRAINT [FK_TodoItems_TodoLists]
GO