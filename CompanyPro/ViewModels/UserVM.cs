using System.ComponentModel.DataAnnotations;

namespace CompanyPro.ViewModels
{
    public class UserVM
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Passwrod { get; set; }
    }
}
