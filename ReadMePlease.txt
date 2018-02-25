1)Open Folder Models and delete all class
2)Open package manager console
3)Type:

Scaffold-DbContext "Data Source=NSQD16\SQL16;Initial Catalog=ECDCNewMIS2017;User ID=MISV2AppUser;Password=Ethics01;MultipleActiveResultSets=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

If you receive an error stating The term 'Scaffold-DbContext' is not recognized as the name of a cmdlet, then close and reopen Visual Studio.

For a new table added in the entityFramework
1) Add the new Table class
2) Copy / paste update code related to new table in the MISContext.cs
3) Copy / Paste code related to new table in linked table class

ET VOILA!!