namespace TestDouble
{
    public interface IGreet
    {
        string Name { get; set; }
        string Hello { get; set; }
        string Good { get; set; }

        string Greet(string message);
    }
}
