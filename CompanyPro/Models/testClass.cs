namespace CompanyPro.Models
{
    public class testClass
    {
        public int Add(int x,int y)
        {
            return x + y;
        }
        public int test()
        {
            int a = 10;
            int b = 20;
           return  Add(a, b);
        }
        private string _name;
        public string NAme
        {
            set
            {
                _name = value;
            }
            get
            {
                //dynamic x = "1";
                //dynamic y = 2;
                //dynamic obj = new Employee();
                //var xx= x + y + obj;//Exception
                return _name;
            }
        }
        public dynamic FullNAme
        {
            set
            {
                //
                NAme= value;
            }
            get
            {
                //
                return NAme;
            }
        }
    }
}
