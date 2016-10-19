using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavAppDesktopRegistration
{
    class BranchModel
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        //public int DepartmentID { get; set; }
        public int CreatedID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedID { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
