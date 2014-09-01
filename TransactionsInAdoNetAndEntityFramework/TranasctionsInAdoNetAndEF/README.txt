Note that you could be using another version of MSSQL. If you are using other than SQLEXPRESS - than change the connection string.

It could be 
<connectionStrings>
    <add name="ATMEntities" connectionString="metadata=res://*/ATM.csdl|res://*/ATM.ssdl|res://*/ATM.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.\;initial catalog=ATM;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" /
</connectionStrings>

or

<connectionStrings>
    <add name="ATMEntities" connectionString="metadata=res://*/ATM.csdl|res://*/ATM.ssdl|res://*/ATM.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.\localhost;initial catalog=ATM;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" /
</connectionStrings>

or something else. Just write your data.

Then by clicking Ctrl + F5 on the console project it will automatically install the entity framework library.