CREATE TABLE [dbo].[HO_Account] (
  [ID] [int] NOT NULL,
  [Name] [varchar](50) NOT NULL,
  [Block_Number] [int] NOT NULL,
  [Lot_Number] [int] NOT NULL,
  [Contact_Number] [varchar](50) NOT NULL,
  CONSTRAINT [PK_HO_Account] PRIMARY KEY CLUSTERED ([ID])
)
ON [PRIMARY]
GO