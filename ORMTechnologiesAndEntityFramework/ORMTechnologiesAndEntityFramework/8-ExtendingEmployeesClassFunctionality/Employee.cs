using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkLibrary;

namespace _8_ExtendingEmployeesClassFunctionality
{
    public partial class Employee
    {
        private EntityCollection<Territory> entityTerritories;

        public EntityCollection<Territory> EntityTerritories
        {
            get
            {
                var employeeTerritories = this.EntityTerritories;
                EntityCollection<Territory> entityTerritories = new EntityCollection<Territory>();
                entityTerritories.Attach(entityTerritories);
                return entityTerritories;
            }
        }
    }
}
