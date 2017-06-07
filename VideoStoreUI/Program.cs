using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VideoStoreProject;

namespace VideoStoreUI
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoStore videoStore = new VideoStore();
            RentalsMovie rentalsMovie = new RentalsMovie();
            int Choice = 0;
            while (Choice != 6)
            {
                Console.WriteLine();
                Console.WriteLine(" välja nummer de alternativ");
                Console.WriteLine("------------------------");
                Console.WriteLine("1- Get Customers ");
                Console.WriteLine("2- Add New Custmors");
                Console.WriteLine("3- Add New Movie");
                Console.WriteLine("4- Rent Movie");
                Console.WriteLine("5- Get Rentals For SSN");
                Console.WriteLine("6- Exit");
                try
                {
                    Choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Ogiltig markering. Vänligen returnera ditt val.");
                }
                Console.WriteLine("Du valde: " + Choice);

                switch (Choice)
                {
                    case 1:
                       var get =videoStore.GetCustomers();
                        get.ForEach(c=> Console.WriteLine(c.Name,c.SSn));
                       
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Enter Movie Title :");
                       var title=Console.ReadLine();
                        Console.WriteLine("Enter SSN :");
                        var ssn = Console.ReadLine();
                        videoStore.RegisterCustomer(title,ssn);
                        break;
                    case 3:
                        Console.WriteLine("Write Movie Title");
                        var inp = Console.ReadLine();
                        Movie m =new Movie { MovieTitle = inp};
                        
                       videoStore.AddMovie(m);
                        break;
                    case 4:
                        Console.WriteLine("Enter Movie Title :");
                        var Mov = Console.ReadLine();
                        Console.WriteLine("Enter SSN :");
                        var ssnM = Console.ReadLine();
                        videoStore.RentMovie(Mov,ssnM);
                        break;
                    case 5:
                        Console.WriteLine("Enter SSN :");
                        var ssnMRent = Console.ReadLine();
                        rentalsMovie.GetRentalsFor(ssnMRent);
                        break;
                    default:
                        Console.WriteLine("Tryck Inter för att fortsätta.......");
                        Console.ReadLine();
                        break;
                }
                Console.Clear();
            }
        }
    }
}
