# member

資料庫使用 SQL Server，請還原資料庫備份檔Demo.bak，或是在資料庫建立Member資料表
SQL指令如下:

CREATE TABLE [dbo].[Member](
[Id] [int] IDENTITY(1,1) NOT NULL,
[Account] [varchar](20) NULL,
[Password] [varchar](50) NULL,
[Name] [varchar](20) NULL,
	CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
	(
	[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
----------------------

請在appsettings.json 修改連線字串，輸入相對應的資料如下:

"ConnectionStrings": {
    "Sample": "Server=YourLocalDB;Database=YourDatabase;User Id=YourID;Password=YourPassword;"
  }
