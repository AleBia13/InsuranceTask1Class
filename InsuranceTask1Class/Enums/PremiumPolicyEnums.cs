using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceTask1Class.Enums
{
    public enum PricingModelType
    {
        FlatRate,
        AgeRate,
        GenderAgeRate
    }

    public enum ProrateCalculationType
    {
        ByDays,
        ByMonths
    }
}
