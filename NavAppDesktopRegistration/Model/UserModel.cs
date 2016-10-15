using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavAppDesktopRegistration
{
    public class UserModel : EmployeeModel
    {
        public int UserID { get; set; }
        public bool IsSuperAdmin { get; set; }

        //add more Properties see Database Table
    }
}
