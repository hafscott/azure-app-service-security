declare @username nvarchar(max)

select @username = N'easyauthdemouser'

if not exists (select * from sys.sql_logins where [name] = @username)
BEGIN
	CREATE LOGIN [easyauthdemouser] 
	WITH PASSWORD = 'Pa$$word' 
END

