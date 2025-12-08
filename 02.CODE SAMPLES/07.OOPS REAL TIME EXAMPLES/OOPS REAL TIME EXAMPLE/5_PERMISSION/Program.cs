using System;
using System.Collections.Generic;

namespace _5_PERMISSION
{
    public enum permissionType
    {
        read,
        write,
        delete
    }

    public class role
    {
        private string roleName;
        private List<permissionType> permissions = new List<permissionType>();

        public role(string roleName, List<permissionType> permission)
        {
            this.roleName = roleName;
            this.permissions = permission;
        }

        public bool Haspermission(permissionType permission)
        {
            return this.permissions.Contains(permission);
        }
        
    }

    public class user
    {
        private string username;

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
