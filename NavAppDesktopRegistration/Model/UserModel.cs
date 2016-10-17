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
        public int EmployeeID { get; set; }
        public string Password { get; set; }
        public string PreviousPassword { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        //add more Properties see Database Table
    }
}
