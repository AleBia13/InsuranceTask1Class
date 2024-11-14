using InsuranceTask1Class.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceTask1Class.DTO
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Company { get; set; }
        public DateTime AdditionDate { get; set; }
    }
}
