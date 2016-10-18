using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavAppDesktopRegistration
{

    public enum RanksEnum:short
    {
        [Description("Leading Seaman")]
        LeadingSeaman = 1,
        [Description("Petty Officer")]
        PettyOfficer = 2,
        [Description("Chief Petty Officer")]
        ChiefPattyOfficer = 3,
        [Description("Master Chief Petty Officer")]
        MasterChiefPettyOfficer = 4,
        [Description("Midshipman")]
        MidShipMan = 5,
        [Description("Sub Lieutenant")]
        SubLieutenant = 6,
        [Description("Lieutenant")]
        Lieutenant = 7,
        [Description("Lieutenant Commander")]
        LieutenantCommander = 8,
        [Description("Captain")]
        Captain = 9,
        [Description("Comodor")]
        Comodor = 10,
        [Description("Rear Admiral")]
        RearAdmiral = 11,
        [Description("Vice Admiral")]
        ViceAdmiral = 12

    }
    public enum MarriedEnum:short
    {
        [Description("Unmarried")]
        Unmarried = 0,
        [Description("Married")]
        Married = 1
    }
    public enum BloodGroupEnum:short
    {
        [Description("A+")]
        APositive = 1,
        [Description("A-")]
        ANegative = 2,
        [Description("B+")]
        BPositive = 3,
        [Description("B-")]
        BNegative  =4,
        [Description("O+")]
        OPositive = 5,
        [Description("O-")]
        ONegative = 6,
        [Description("AB+")]
        ABPositive = 7,
        [Description("AB-")]
        ABNegative =8

    }
}
