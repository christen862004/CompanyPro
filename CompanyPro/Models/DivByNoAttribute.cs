using System.ComponentModel.DataAnnotations;

namespace CompanyPro.Models
{
    public class DivByNoAttribute:ValidationAttribute
    {
        public DivByNoAttribute(int no)
        {
            Number = no;
            
        }
        public int Number { get; set; }//5

        public override bool IsValid(object? value)//check /no
        {
            int s =int.Parse(value.ToString());
            if (s % Number == 0)
                return true;
            return false;
        }
    }
}
