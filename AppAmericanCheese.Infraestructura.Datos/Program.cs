using System;

namespace AppAmericanCheese.Infraestructura.Datos
{
    class Program
    {
        static void Main(string[] args)
        {
            DbAmericanCheese db = new DbAmericanCheese();
            db.Database.EnsureCreated();
            Console.WriteLine("success full");
        }
    }
}
