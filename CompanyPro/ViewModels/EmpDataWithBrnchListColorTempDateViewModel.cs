using CompanyPro.Models;

namespace CompanyPro.ViewModels
{
    public class EmpDataWithBrnchListColorTempDateViewModel
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public List<string> Brcnches { get; set; }
        public string Msg { get; set; }
        public string Color { get; set; }
        public int Temp { get; set; }
    }
}
