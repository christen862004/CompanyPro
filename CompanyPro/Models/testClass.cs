using Microsoft.DiaSymReader;

namespace CompanyPro.Models
{
    public interface ISort
    {
        void Sort();
    }

    public class BubbleSort:ISort
    {
        public void Sort()
        {
            //using bubble sort
        }
    }

    public class SelectionSort : ISort
    {
        public void Sort()
        {
            //using Selection sort
        }
    }
    public class ChrisSort : ISort
    {
        public void Sort() { }
    }
    //IOC :dont class tigh couple ,lossly couple
    //DIP :high level (MyList) class depend low level (BubbleSort) class ,
    //     depend on abstraction (class -interface)
    public class  MyList
    {
        ISort sortAlg;// = new BubbleSort();
        public MyList(ISort sort)//create object 
        {
            sortAlg = sort;
        }
        public void display(ISort sort)
        {

        }
        public void SortList()
        {
            sortAlg.Sort();
        }
    }




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
        public void Method1()
        {
            MyList list1 = new MyList(new BubbleSort());
            MyList list2 = new MyList(new SelectionSort());
            MyList list3 = new MyList(new ChrisSort());//dIP (

            Method2();
            //
        }
        public void Method2()
        {
            //Method3();
        }
        
    }
}
