using EntityFrameworkLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_UsersAndGroups
{
    class Program
    {
        static void CreateUser(string userName, string password, int groupId)
        {
            UsersAndGroupsEntities context = new UsersAndGroupsEntities();

            using(context)
            {
                var user = new User
                {
                    UserName = userName,
                    Password = password,
                    GroupID = groupId
                };

                context.Users.Add(user);

                context.SaveChanges();

                Console.WriteLine("New User Added!");
            }
        }

        private static void CreateGroupAdmin(string groupName)
        {
            UsersAndGroupsEntities context = new UsersAndGroupsEntities();

            using(context)
            {
                var adminsGroup = new Group
                {
                    GroupName = groupName
                };

                context.Groups.Add(adminsGroup);

                context.SaveChanges();

                Console.WriteLine("Admin group added!");
            }
        }

        static void Main()
        {
            UsersAndGroupsEntities context = new UsersAndGroupsEntities();

            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                using (context)
                {

                    if (!context.Groups.Any(g => g.GroupName == "Admins"))
	                {
		                CreateGroupAdmin("Admins");
	                }

                    var adminsGroup = context.Groups.Where(g => g.GroupName == "Admins").FirstOrDefault();
                    int adminsGroupId = adminsGroup.GroupID;

                    CreateUser("Pesho", "12345", adminsGroupId);
                    context.SaveChanges();

                    dbContextTransaction.Rollback();

                    Console.WriteLine("Transaction ended!");
                }
            }
        }
    }
}
