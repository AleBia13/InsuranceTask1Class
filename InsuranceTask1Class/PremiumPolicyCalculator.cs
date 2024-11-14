using InsuranceTask1Class.DTO;
using InsuranceTask1Class.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceTask1Class
{
    public delegate decimal PricingModel(int age, Gender gender);

    public delegate decimal ProrateCalculator(decimal fullPremium, DateTime additionDate, DateTime policyEndDate);


    public class PremiumPolicyCalculator
    {
        public Tuple<Guid, decimal, decimal> CalculatePremium(EmployeeDTO employee, PremiumPolicyDTO premiumPolicy)
        {
            try
            {
                var pricingModel = GetPricingModel(premiumPolicy.PricingModelType);
                var prorateCalculator = GetProrateCalculator(premiumPolicy.ProrateCalculationType);

                var fullPremium = pricingModel(employee.Age, employee.Gender);
                var proratePrice = prorateCalculator(fullPremium, employee.AdditionDate, premiumPolicy.PolicyEndDate);
                return Tuple.Create(employee.Id, fullPremium, proratePrice);
            }
            catch (Exception ex)
            {

                throw new Exception("Error calculating premium", ex);
            }
        }

        private PricingModel GetPricingModel(PricingModelType policyType)
        {
            return policyType switch
            {
                PricingModelType.FlatRate => FlatRatePricing,
                PricingModelType.AgeRate => AgeRatePricing,
                PricingModelType.GenderAgeRate => GenderAgeRatePricing,
                _ => throw new ArgumentOutOfRangeException(nameof(policyType), policyType, null),
            };
        }

        private ProrateCalculator GetProrateCalculator(ProrateCalculationType prorateCalculationType)
        {
            return prorateCalculationType switch
            {
                ProrateCalculationType.ByDays=> ProrateByDays,
                ProrateCalculationType.ByMonths => ProrateByMonths,
                _ => throw new ArgumentOutOfRangeException(nameof(prorateCalculationType), prorateCalculationType, null),
            };
        }

        #region PrincingModels
        private decimal FlatRatePricing(int age, Gender gender)
        {
            return Math.Round(1000m, 2);
        }

        private decimal AgeRatePricing(int age, Gender gender)
        {
            var multiplier = (age / 10 + 1) * 100m;
            return Math.Round(multiplier, 2);
        }

        private decimal GenderAgeRatePricing(int age, Gender gender)
        {
            var basePremium = (age / 10 + 1) * 100m;
            if (gender == Gender.Female && age > 18)
            {
                basePremium *= 1.5m;
            }
            return Math.Round(basePremium, 2);
        }
        #endregion

        #region ProrateCalculator 

        private decimal ProrateByDays(decimal fullPremium, DateTime additionDate, DateTime policyEndDate)
        {
            var days = (policyEndDate - additionDate).Days + 1;
            return Math.Round(fullPremium / 366 * days, 2);
        }

        private decimal ProrateByMonths(decimal fullPremium, DateTime additionDate, DateTime policyEndDate)
        {
            var months = ((policyEndDate.Year - additionDate.Year) * 12) + policyEndDate.Month - additionDate.Month + 1;
            return Math.Round(fullPremium / 12 * months, 2);
        }

        #endregion
    }
}
