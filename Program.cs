using System;
using System.Collections.Generic;
using System.Text;
using DesafioProjetoHospedagem.Models;

namespace DesafioProjetoHospedagem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Reservation currentReservation = new Reservation();

            bool showMenu = true;
            Console.WriteLine("Welcome to the Hotel Reservation System!");

            while (showMenu)
            {
                Console.WriteLine("\n--- Main Menu ---");
                Console.WriteLine("1. Configure Suite");
                Console.WriteLine("2. Add Guests");
                Console.WriteLine("3. Set Reservation Days");
                Console.WriteLine("4. View Reservation Details & Calculate Cost");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string? input = Console.ReadLine();
                if (!int.TryParse(input, out int option))
                {
                    Console.WriteLine("Invalid input. Please enter a number from the menu");
                    continue;
                }

                try
                {
                    switch (option)
                    {
                        case 1:
                            ConfigureSuite(currentReservation);
                            break;
                        case 2:
                            AddGuests(currentReservation);
                            break;
                        case 3:
                            SetReservationDays(currentReservation);
                            break;
                        case 4:
                            ViewReservationDetails(currentReservation);
                            break;
                        case 5:
                            showMenu = false;
                            Console.WriteLine("Exiting the program. Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please choose a number between 1 and 5");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nAn error occurred: {ex.Message}");
                    Console.WriteLine("Please ensure all necessary details (Suite, Guests, Days) are correctly configured");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear(); // Limpeza de tela para melhor visualização
            }
        }

        static void ConfigureSuite(Reservation reservation)
        {
            Console.WriteLine("\n--- Configure Suite ---");
            Console.Write("Enter Suite Type (e.g., Standard, Premium, Master): ");
            string? suiteType = Console.ReadLine();

            int capacity;
            Console.Write("Enter Suite Capacity: ");
            while (!int.TryParse(Console.ReadLine(), out capacity) || capacity <= 0)
            {
                Console.WriteLine("Invalid capacity. Please enter a positive whole number");
                Console.Write("Enter Suite Capacity: ");
            }

            decimal dailyValue;
            Console.Write("Enter Daily Value in USD: ");
            while (!decimal.TryParse(Console.ReadLine(), out dailyValue) || dailyValue <= 0)
            {
                Console.WriteLine("Invalid daily value. Please enter a positive number (Exemple: 150.00)");
                Console.Write("Enter Daily Value in USD: ");
            }

            Suite newSuite = new Suite(suiteType ?? "Default", capacity, dailyValue);
            reservation.RegisterSuite(newSuite);

            Console.WriteLine("Suite configured successfully!");
        }

        static void AddGuests(Reservation reservation)
        {
            Console.WriteLine("\n--- Add Guests ---");

            if (reservation.Suite == null)
            {
                Console.WriteLine("Please configure the suite first (Option 1) to set capacity limits.");
                return;
            }

            List<Person> guestList = new List<Person>();
            string? guestName;
            int guestCount = 0;

            Console.WriteLine($"Suite Capacity: {reservation.Suite.Capacity}");
            Console.WriteLine("Enter guest names one by one. Type 'done' to finish.");

            while (true)
            {
                if (guestCount >= reservation.Suite.Capacity)
                {
                    Console.WriteLine("You have reached the suite capacity. Cannot add more guests.");
                    break;
                }

                Console.Write($"Guest #{guestCount + 1}: ");
                guestName = Console.ReadLine();

                if (guestName?.ToLower() == "done")
                    break;

                if (string.IsNullOrWhiteSpace(guestName))
                {
                    Console.WriteLine("Guest name cannot be empty.");
                    continue;
                }

                guestList.Add(new Person(guestName));
                guestCount++;
            }

            try
            {
                reservation.RegisterGuests(guestList);
                Console.WriteLine($"{guestCount} guests registered successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error adding guests: {ex.Message}");
                reservation.Guests = new List<Person>(); // Clear if error
            }
        }

        static void SetReservationDays(Reservation reservation)
        {
            Console.WriteLine("\n--- Set Reservation Days ---");

            int days;
            Console.Write("Enter number of days: ");
            while (!int.TryParse(Console.ReadLine(), out days) || days <= 0)
            {
                Console.WriteLine("Invalid number of days. Please enter a positive integer.");
                Console.Write("Enter number of days: ");
            }

            reservation.ReservedDays = days;
            Console.WriteLine($"Reservation set for {days} days.");
        }

        static void ViewReservationDetails(Reservation reservation)
        {
            Console.WriteLine("\n--- Reservation Details ---");

            if (reservation.Suite == null)
            {
                Console.WriteLine("Suite not configured.");
            }
            else
            {
                Console.WriteLine($"Suite Type: {reservation.Suite.SuiteType}");
                Console.WriteLine($"Capacity: {reservation.Suite.Capacity}");
                Console.WriteLine($"Daily Rate: ${reservation.Suite.DailyValue:F2}");
            }

            if (reservation.Guests == null || reservation.Guests.Count == 0)
            {
                Console.WriteLine("No guests added.");
            }
            else
            {
                Console.WriteLine($"Guest Count: {reservation.GetGuestCount()}");
                Console.WriteLine("Guest Names:");
                foreach (var guest in reservation.Guests)
                {
                    Console.WriteLine($"- {guest.Name}");
                }
            }

            if (reservation.ReservedDays <= 0)
            {
                Console.WriteLine("Reserved days not set");
            }
            else
            {
                Console.WriteLine($"Days Reserved: {reservation.ReservedDays}");
            }

            if (reservation.Suite != null && reservation.Guests != null &&
                reservation.Guests.Count > 0 && reservation.ReservedDays > 0)
            {
                try
                {
                    decimal total = reservation.CalculateTotalValue();
                    Console.WriteLine($"Total Cost (with any discount): ${total:F2}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Error calculating total: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Cannot calculate total cost. Please complete all reservation steps");
            }
        }
    }
}
