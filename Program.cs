Buffet buffet = new Buffet();
SweetTooth sweetTooth = new SweetTooth();
SpiceHound spiceHound = new SpiceHound();

sweetTooth.Consume(buffet.Serve());
sweetTooth.Consume(buffet.Serve());

spiceHound.Consume(buffet.Serve());
spiceHound.Consume(buffet.Serve());

if (spiceHound.ConsumptionHistory.Count == sweetTooth.ConsumptionHistory.Count)
{
    Console.WriteLine("spiceHound y sweetTooth consumieron lo mismo.");
}
else if (spiceHound.ConsumptionHistory.Count > sweetTooth.ConsumptionHistory.Count)
{
    Console.WriteLine("spiceHound consumió mas que sweetTooth");
}
else
{
    Console.WriteLine("sweetTooth consumió mas que spiceHound");
}

Console.WriteLine("spiceHound cantidad elementos consumidos : " + spiceHound.ConsumptionHistory.Count);
Console.WriteLine("sweetTooth cantidad elementos consumidos : " + spiceHound.ConsumptionHistory.Count);

interface IConsumable
{
    string Name { get; set; }
    int Calories { get; set; }
    bool IsSpicy { get; set; }
    bool IsSweet { get; set; }
    string GetInfo();
}

class Food : IConsumable
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public bool IsSpicy { get; set; }
    public bool IsSweet { get; set; }
    public string GetInfo()
    {
        return $"{Name} (Food).  Calories: {Calories}.  Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
    }
    public Food(string name, int calories, bool spicy, bool sweet)
    {
        Name = name;
        Calories = calories;
        IsSpicy = spicy;
        IsSweet = sweet;
    }
}

class Drink : IConsumable
{


    public string Name { get; set; }
    public int Calories { get; set; }
    public bool IsSpicy { get; set; }
    public bool IsSweet { get; set; }



    // Implement a GetInfo Method
    public string GetInfo()
    {
        return $"{Name} (Food).  Calories: {Calories}.  Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
    }
    // Add a constructor method
    public Drink(string name, int calories, bool isSpicy, bool isSweet)
    {
        Name = name;
        Calories = calories;
        IsSpicy = isSpicy;
        IsSweet = isSweet;
    }
}
class Buffet
{
    public List<IConsumable> Menu;

    //constructor
    public Buffet()
    {
        Menu = new List<IConsumable>()
        {
            new Food("Carne", 1200, false, false),
            new Food("Helado", 2000, false, true),
            new Food("Frutas", 1400, false, true),
            new Food("Pan Con carne", 1300, false, false),
            new Food("Costillar", 1300, false, false),
            new Food("Costillar Argentino", 1650, false, false),
            new Food("Costillar Brasileño", 1700, false, false),
            new Drink("Coca", 1700, false, true),
            new Drink("Pepsi", 1700, false, true),
        };
    }

    public IConsumable Serve()
    {
        Random rand = new Random();
        int result = rand.Next(0, Menu.Count);
        return Menu[result];
    }
};
abstract class Ninja
{
    protected int calorieIntake;
    public List<IConsumable> ConsumptionHistory;
    public Ninja()
    {
        calorieIntake = 0;
        ConsumptionHistory = new List<IConsumable>();
    }
    public abstract bool IsFull { get; }
    public abstract void Consume(IConsumable item);
}
class SweetTooth : Ninja
{
    // provide override for IsFull (Full at 1500 Calories)
    public override bool IsFull
    {
        get
        {
            if (calorieIntake > 1500)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public override void Consume(IConsumable item)
    {
        if (!IsFull)
        {
            if (item.IsSweet)
            {
                calorieIntake += item.Calories + 10;
            }
            else
            {
                calorieIntake += item.Calories;
            }
            ConsumptionHistory.Add(item);
            item.GetInfo();
        }
        else
        {
            Console.WriteLine("SweetTooth is full.");
        }
    }
}
class SpiceHound : Ninja
{
    public override bool IsFull
    {
        get
        {
            if (calorieIntake > 1200)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public override void Consume(IConsumable item)
    {
        if (!IsFull)
        {
            if (item.IsSpicy)
            {
                calorieIntake += item.Calories - 5;
            }
            else
            {
                calorieIntake += item.Calories;
            }
            ConsumptionHistory.Add(item);
            item.GetInfo();
        }
        else
        {
            Console.WriteLine("SpiceHound is full.");
        }
    }
}