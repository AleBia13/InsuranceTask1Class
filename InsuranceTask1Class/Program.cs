using InsuranceTask1Class;
using InsuranceTask1Class.DTO;
using InsuranceTask1Class.Enums;

internal class Program
{
    private static void Main(string[] args)
    {
        var premiumPolicy = new PremiumPolicyDTO()
        {
            Company = "Teambase",
            Id = new Guid(),
            Employees = new List<EmployeeDTO>()
            {
                new EmployeeDTO()
                {
                    Id = new Guid(),
                    Age = 25,
                }
            },
            PolicyEndDate = DateTime.Now.AddDays(5),
            PricingModelType = PricingModelType.AgeRate,
            ProrateCalculationType = ProrateCalculationType.ByDays
        };

        var newEmployee = new EmployeeDTO()
        {
            Id = new Guid(),
            Age = 25,
            Gender = Gender.Male,
            AdditionDate = DateTime.Now,
            Company = "Teambase"
        };
        var calculator = new PremiumPolicyCalculator();

        if (premiumPolicy.PolicyEndDate <= DateTime.Now)
        {
            Console.WriteLine("The policy has expired");
            return;
        }

        if (newEmployee.Company != premiumPolicy.Company)
        {
            Console.WriteLine("Employee does not belong to the company");
            return;
        }

        var result = calculator.CalculatePremium(newEmployee, premiumPolicy);
        Console.WriteLine($"Employee {result.Item1} has full premium of {result.Item2} USD and prorate of {result.Item3} USD");
    }
}
