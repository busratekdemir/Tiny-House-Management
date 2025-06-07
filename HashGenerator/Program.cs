using System;
using BCrypt.Net;

namespace HashGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hash’ini almak istediğin şifreyi girin: ");
            string plain = Console.ReadLine();

            // Bcrypt ile hash üret
            string hash = BCrypt.Net.BCrypt.HashPassword(plain);

            Console.WriteLine("\nOluşan hash:\n" + hash);
            Console.WriteLine("\nÇıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
