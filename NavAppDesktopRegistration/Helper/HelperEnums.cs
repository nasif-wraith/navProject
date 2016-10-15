using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavAppDesktopRegistration
{

    public enum Ranks:short
    {
        [Description("hsdg sdfgjsdgf sdf gsdfh")]
        leading_seaman = 1,
        petty_officer = 2,
        chief_petty_officer = 3,
        master_chief_petty_officer = 4,
        midshipman = 5,
        sub_lieutenant = 6,
        lieutenant = 7,
        lieutenant_commander = 8,
        captain = 9,
        comodor = 10,
        rear_admiral = 11,
        vice_admiral = 12,
        admiral = 14,
        admiral_of_the_fleet = 15
    }
    public enum married
    {
        married = 1,
        unmarried = 0
    }
    public enum bloodgroup
    {
        A_positive = 1,
       A_negative = 2,
        B_positive = 3,
        B_negative  =4,
        O_positive = 5,
        O_negative = 6,
        AB_positive = 7,
        AB_negative =8

    }
}
