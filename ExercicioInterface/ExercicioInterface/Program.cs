using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using ExercicioInterface.Entities;
using ExercicioInterface.Services;

namespace ExercicioInterface
{
    class Program
    {
        static void Main (string[] args)
        {
            Console.WriteLine("Enter rental data: ");
            Console.WriteLine("Car model: ");
            string model = Console.ReadLine();
            Console.WriteLine("Pickup date: (dd/MM/yyyy HH:mm)");
            DateTime pickup = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.WriteLine("Return date: (dd/MM/yyyy HH:mm)");
            DateTime returning = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.WriteLine("Enter price per hour: ");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("Enter price per day: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


            CarRental carRental = new CarRental(pickup, returning, new Vehicle(model));
            RentarService rentalService = new RentarService(hour, day);
            rentalService.ProcessInvoice(carRental);

            Console.WriteLine("INCOIVE:");
            Console.WriteLine(carRental.Invoice);
        }
    }
}
