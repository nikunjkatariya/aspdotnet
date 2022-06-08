using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*            var door = DoorFactory.MakeDoor(100, 20);
                        Console.WriteLine(door.GetHeight());
                        Console.WriteLine(door.GetWidth());*/
            //Bridge
            /*            var darkTheme = new DarkTheme();
                        var lighTheme = new LightTheme();
                        var aquaTheme = new AquaTheme();
                        var career = new Careers(darkTheme);
                        var about = new About(lighTheme);
                        Console.WriteLine(about.GetContent());
                        Console.WriteLine(career.GetContent());*/
            //Composite
            /*            var developer = new DeveloperComposite("Hamed", 10000);
                        var designer = new Designer("Amehe", 110000);

                        var organization = new Organization();
                        organization.AddEmployee(developer);
                        organization.AddEmployee(designer);
                        Console.WriteLine($"Net Salary of Employee in Organization is {organization.GetNetSalaries():c}");*/

            //Decorator
            /*            var myCoffee = new SimpleCoffee();
                        Console.WriteLine(myCoffee.GetCost());
                        Console.WriteLine(myCoffee.GetDescription());
                        var milkCoffee = new SimpleCoffee();
                        Console.WriteLine(milkCoffee.GetCost());
                        Console.WriteLine(milkCoffee.GetDescription());*/

            /*new Prototype().PrototypeMain();*/
            /*new FactoryComposit().Main();*/
            /*new Facade().Main();*/
            /*new Proxy().Main();*/
            new ATMProxy().Main();
        }
    }

    //Simple Factory
    public interface IDoor
    {
        int GetHeight();
        int GetWidth();
    }
    public class WoodneDoor : IDoor
    {
        private int height { get; set; }
        private int width { get; set; }

        public WoodneDoor(int height, int width)
        {
            this.width = width;
            this.height = height;
        }

        public int GetHeight()
        {
            return this.height;
        }

        public int GetWidth()
        {
            return this.width;
        }
    }
    //door Factory
    public static class DoorFactory
    {
        public static IDoor MakeDoor(int height, int width)
        {
            return new WoodneDoor(height, width);
        }
    }

    //Factory Method
    public interface IInterviewer
    {
        void AskQuestions();
    }
    class Developer : IInterviewer
    {
        public void AskQuestions()
        {

        }
    }
    class HRManager : IInterviewer
    {
        public void AskQuestions()
        {

        }
    }
    abstract class HiringManager
    {
        abstract protected IInterviewer MakeInterviewer();
        public void TakeInterView()
        {
            var interviewer = this.MakeInterviewer();
            interviewer.AskQuestions();
        }
        /*        class MarketingManager : HiringManager
                {
                    protected override IInterviewer MakeInterviewer()
                    {
                        return new communityExecutive();
                    }
                }*/
    }



    //Structural Design Pattern
    //Adapter, bridge, composite, decorator, facade, flyweight, proxy
    //purpose: Consern with object conso
    //**********//****Adapter: lets u wrap and incompatible object in adapater to make it compatible in another class
    interface ILion
    {
        void Roar();
    }
    class AfricanLion : ILion
    {
        public void Roar() { }
    }
    class AsianLion : ILion
    {
        public void Roar() { }
    }
    class Hunter
    {
        public void Hunt(ILion lion) { }
    }
    class WildDog
    {
        public void Bark() { }
    }
    class WildDogAdapter : ILion
    {
        private WildDog mDog;
        public WildDogAdapter(WildDog wildDog)
        {
            this.mDog = wildDog;
        }
        public void Roar()
        {
            mDog.Bark();
        }
    }
    //USECASE::::::::
    /*  var wildDog = new WildDog();
        var wildDogAdapater = new WildDogAdapter(wildDog);
        var hunter = new Hunter();
        hunter.Hunt(WildDogAdapter);*/
    //**********//****Bridge: WebApplications, about prefering composition over inheritance where implementation details are pushed from highrarhi with separate highrarchi
    interface IWebPage
    {
        string GetContent();
    }
    class About : IWebPage
    {
        protected ITheme theme;
        public About(ITheme theme)
        {
            this.theme = theme;
        }
        public string GetContent()
        {
            return $"About page in {theme.GetColor()}";
        }
    }
    class Careers : IWebPage
    {
        protected ITheme theme;
        public Careers(ITheme theme)
        {
            this.theme = theme;
        }
        public string GetContent()
        {
            return $"Career page in {theme.GetColor()}";
        }
    }
    interface ITheme
    {
        string GetColor();
    }
    class LightTheme : ITheme
    {
        public string GetColor()
        {
            return "White";
        }
    }
    class AquaTheme : ITheme
    {
        public string GetColor()
        {
            return "Aqua";
        }
    }
    class DarkTheme : ITheme
    {
        public string GetColor()
        {
            return "Dark Black";
        }
    }
    //USECASE:::::::::::
    /*   var darkTheme = new DarkTheme();
       var lighTheme = new LightTheme();
       var aquaTheme = new AquaTheme();
       var career = new Careers(darkTheme);
       var about = new About(lightTheme);
       Console.WriteLine(about.GetContent());
       Console.WriteLine(Careers.GetContent());*/
    //************//****Composite: lets client objects in a uniform Maner, partitioning Designing Pattern, which describes each object is a sigletone 
    // the intent of composite to compose in to tree structure to represent parthole hirarchi, lets client reads individual composition and objects uniformly
    interface IEmployee
    {
        float GetSalary();
        string GetRole();
        string GetName();
    }
    class DeveloperComposite : IEmployee
    {
        private string mName;
        private float mSalary;
        public DeveloperComposite(string name, float salary)
        {
            this.mName = name;
            this.mSalary = salary;
        }
        public string GetName()
        {
            return this.mName;
        }
        public string GetRole()
        {
            return "Developer";
        }
        public float GetSalary()
        {
            return this.mSalary;
        }
    }
    class Designer : IEmployee
    {
        private string mName;
        private float mSalary;
        public Designer(string name, float salary)
        {
            this.mName = name;
            this.mSalary = salary;
        }
        public string GetName()
        {
            return this.mName;
        }
        public string GetRole()
        {
            return "Developer";
        }
        public float GetSalary()
        {
            return this.mSalary;
        }
    }
    class Organization
    {
        protected List<IEmployee> employees;
        public Organization()
        {
            employees = new List<IEmployee>();
        }
        public void AddEmployee(IEmployee employee)
        {
            employees.Add(employee);
        }
        public float GetNetSalaries()
        {
            float netSalary = 0;
            foreach (var e in employees)
            {
                netSalary += e.GetSalary();
            }
            return netSalary;
        }
    }
    //USECASE::::::::::
    /*    var developer = new Developer("Hamed", 10000);
        var designer = new Designer("Amehe", 110000);

        var organization = new Organization();
        organization.AddEmployee(developer);
        organization.AddEmployee(designer);
        Console.WriteLine($"Net Salary of Employee in Organization is {organization.GetNetSalaries():c}");*/

    //************//******Decorator: Dynamically chages the behavior of an object at run time by wrapping them in an object of a Decorattor Class
    interface ICoffee
    {
        int GetCost();
        string GetDescription();
    }
    class SimpleCoffee : ICoffee
    {
        public int GetCost()
        {
            return 5;
        }
        public string GetDescription()
        {
            return "Simple Coffee";
        }
    }
    class MilkCoffee : ICoffee
    {
        private readonly ICoffee mCoffee;
        public MilkCoffee(ICoffee coffee)
        {
            mCoffee = coffee ?? throw new ArgumentNullException("Coffee", "coffee should not be null");
        }
        public int GetCost()
        {
            return mCoffee.GetCost() + 1;
        }
        public string GetDescription()
        {
            return string.Concat(mCoffee.GetDescription(), ",milk");
        }
    }
    //USECASE::::::::::::
/*    var myCoffee = new SimpleCoffee();
    Console.WriteLine({myCoffee.GetCost():c});
    Console.WriteLine({myCoffee.GetDescription()});
    var milkCoffee = new SimpleCoffee();
    Console.WriteLine({ myCoffee.GetCost():c});
    Console.WriteLine({ myCoffee.GetDescription()});*/
}