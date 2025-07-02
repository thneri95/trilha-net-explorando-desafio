using System;
using System.Collections.Generic;

namespace DesafioProjetoHospedagem.Models
{
    public class Reservation
    {
        public List<Person> Guests { get; set; } = new List<Person>();
        public Suite? Suite { get; private set; }
        public int ReservedDays { get; set; }

        public Reservation() { }

        public Reservation(int reservedDays)
        {
            ReservedDays = reservedDays;
        }

        public void RegisterGuests(List<Person> guests)
        {
            if (Suite == null)
                throw new InvalidOperationException("A suite must be registered before adding guests");

            if (guests == null || guests.Count == 0)
                throw new ArgumentException("Guest list cannot be empty");

            if (guests.Count > Suite.Capacity)
                throw new ArgumentException($"The number of guests ({guests.Count}) exceeds the suite capacity ({Suite.Capacity}).");

            Guests = guests;
        }

        public void RegisterSuite(Suite suite)
        {
            Suite = suite ?? throw new ArgumentNullException(nameof(suite), "Suite cannot be null");
        }

        public int GetGuestCount()
        {
            return Guests?.Count ?? 0;
        }

        public decimal CalculateTotalValue()
        {
            if (Suite == null)
                throw new InvalidOperationException("Suite must be registered before calculating the reservation cost");

            if (ReservedDays <= 0)
                throw new InvalidOperationException("Number of reserved days must be greater than zero");

            decimal total = ReservedDays * Suite.DailyValue;

            // To Apply 10% discount for 10 or more days:
            if (ReservedDays >= 10)
                total *= 0.90m;

            return total;
        }
    }
}
