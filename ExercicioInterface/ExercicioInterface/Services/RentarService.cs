using ExercicioInterface.Entities;

namespace ExercicioInterface.Services
{
    internal class RentarService
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        private BrazilTaxService _brazilTaxService = new BrazilTaxService();

        public RentarService(double pricePerHour, double pricePerDay)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);

            double basicPayment = 0.0;
            if(duration.TotalHours <= 12.0)
            {
                basicPayment = (Math.Ceiling(duration.TotalHours) * PricePerHour);
            }
            else
            {
                basicPayment = (Math.Ceiling(duration.TotalDays) * PricePerDay);
            }

            double tax = _brazilTaxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
