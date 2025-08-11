namespace FluentApiApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new FluentConfigurator<Pizza>(p => p.Size)
            .HasMaxLength(100);

            Console.WriteLine($"Hello, {config.ToString()}");
        }

        
        
    }
}
