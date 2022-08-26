CREATE TABLE [dbo].[tbOrder]
(
	[orderid] INT NOT NULL IDENTITY , 
    [orderdate] INT NOT NULL, 
    [pid] INT NOT NULL, 
    [pname] VARCHAR(50) NOT NULL, 
    [cid] INT NOT NULL, 
    [cname] VARCHAR(50) NOT NULL, 
    [quantity] INT NOT NULL, 
    [price] INT NOT NULL, 
    [total] INT NOT NULL, 
    PRIMARY KEY ([orderid])
)
