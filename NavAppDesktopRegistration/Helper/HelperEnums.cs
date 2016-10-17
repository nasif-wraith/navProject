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
        [Description("leading seaman")]
        leading_seaman = 1,
        [Description("petty officer")]
        petty_officer = 2,
        [Description("chief petty officer")]
        chief_petty_officer = 3,
        [Description("master chief petty officer")]
        master_chief_petty_officer = 4,
        [Description("midshipman")]
        midshipman = 5,
        [Description("sub lieutenant")]
        sub_lieutenant = 6,
        [Description("lieutenant")]
        lieutenant = 7,
        [Description("lieutenant commander")]
        lieutenant_commander = 8,
        [Description("captain")]
        captain = 9,
        [Description("comodor")]
        comodor = 10,
        [Description("rear admiral")]
        rear_admiral = 11,
        [Description("vice admiral")]
        vice_admiral = 12

    }
    public enum marriedEnum
    {
        married = 1,
        unmarried = 0
    }
    public enum bloodgroupEnum
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
