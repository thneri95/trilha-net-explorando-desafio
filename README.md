# 🏨 Hotel Reservation System – C# Console App

[![.NET](https://img.shields.io/badge/.NET-7.0-blue)](https://dotnet.microsoft.com/en-us/)


> A dynamic  hotel reservation system built with C# and .NET. Manage suites, guests, and calculate discounts—all in a simple interactive console interface

---


## 📦 Features

| #   | Feature                          | Status      |
|-----|----------------------------------|-------------|
| ✅ | Configure Suite (type, capacity) | ✔️ Complete |
| ✅ | Add Guests with validation       | ✔️ Complete |
| ✅ | Set Reservation Days             | ✔️ Complete |
| ✅ | Calculate Price + Discounts      | ✔️ Complete |
| 🔜 | Guest age/ID fields              | 🚧 Planned  |
| 🔜 | Save/load from file/database     | 🚧 Planned  |

---

## 🧠 System Flow

1️⃣ Configure Suite
2️⃣ Add Guests (validate by capacity)
3️⃣ Set Reservation Days
4️⃣ View Summary + Calculate Price (with 10% discount for 10+ days)

## 📊 Business Logic
💰 Discount Rule
Reservations with 10 or more days get a 10% discount on total value.

🧮 Price Formula

Total = Days Reserved × Daily Value
If Days >= 10 → Apply 10% discount

## ✅ Example Simple Output

Welcome to the Hotel Reservation System!

--- Main Menu ---
1. Configure Suite
2. Add Guests
3. Set Reservation Days
4. View Reservation Details & Calculate Cost
5. Exit

> Total Reservation Value: $2,160.00


## Reservation  Output

--- Reservation Details ---
Suite Type: Master
Capacity: 10
Daily Rate: $300.00
Guest Count: 4
Guest Names:
- Harry  
- Joe 
- Mike
- Chloe

Days Reserved: 11
Total Cost (with any discount): $2970.00

---------------------------

## 🛠 Technologies

C# / .NET;
Console Application;
OOP (Encapsulation, Composition, Abstraction);
List<T>, Exception Handling; 
Input validation & business rules;

## 👤 Author
Tiago Borges - Thneri95

Contributions, feedback are welcome!



