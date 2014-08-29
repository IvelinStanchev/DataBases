1) Go to StudentSystem.Data
2) Right mouse click and click to Manage NuGet Packages. In the window opened click at the top right corner 'Restore'. This will restore the Entity Framework.
3) Check the connectionStrings. If you are not using SQLEXPRESS then go and change the default database you your one (localhost maybe ...)
4) Make StudentSystem.Client your startup project
5) Now you can check the tasks solutions.