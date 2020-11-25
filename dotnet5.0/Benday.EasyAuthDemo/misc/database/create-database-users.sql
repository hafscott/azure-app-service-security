declare @username nvarchar(max)

select @username = N'easyauthdemouser'

if not exists (SELECT * FROM [sys].[database_principals] where [name] = @username)
BEGIN
	CREATE USER easyauthdemouser
		FOR LOGIN easyauthdemouser
		WITH DEFAULT_SCHEMA = dbo

	EXEC sp_addrolemember N'db_datareader', N'easyauthdemouser'

	EXEC sp_addrolemember N'db_datawriter', N'easyauthdemouser'
END
ELSE
BEGIN
	EXEC sp_addrolemember N'db_datareader', N'easyauthdemouser'

	EXEC sp_addrolemember N'db_datawriter', N'easyauthdemouser'
END