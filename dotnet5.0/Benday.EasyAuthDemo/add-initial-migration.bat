set base=%cd%
cd src\Benday.EasyAuthDemo.Api

dotnet ef migrations add InitialSetup

cd %base%