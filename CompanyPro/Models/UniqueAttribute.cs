using System.ComponentModel.DataAnnotations;

namespace CompanyPro.Models
{
    public class UniqueAttribute:ValidationAttribute
    {


        //check emp name must be unique(server side validation)
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            
            string name = value.ToString();
            Employee EmpFromRequest = 
                (Employee)validationContext.ObjectInstance;
            
            ITIContext context = validationContext.GetService<ITIContext>();

            Employee EmpFromDB= context.Employee
                .FirstOrDefault(e => e.Name == name && e.DepartmentId==EmpFromRequest.DepartmentId);
            
            if(EmpFromDB == null) {
                return ValidationResult.Success;
            }
            //logic
            return new ValidationResult("Name Already exists");
        }
    }
}
