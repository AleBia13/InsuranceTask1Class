using InsuranceTask1Class.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceTask1Class.DTO
{
    public class PremiumPolicyDTO
    {
        public Guid Id { get; set; }
        public string Company { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
        public DateTime PolicyEndDate { get; set; }
        public PricingModelType PricingModelType { get; set; }
        public ProrateCalculationType ProrateCalculationType { get; set; }
    }
}
