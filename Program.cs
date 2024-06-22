using System;

namespace ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parkingLot = null;

            while (true)
            {
                string input = Console.ReadLine();
                string[] command = input.Split(' ');

                switch (command[0])
                {
                    case "create_parking_lot":
                        int totalSlots = int.Parse(command[1]);
                        parkingLot = new ParkingLot(totalSlots);
                        Console.WriteLine($"Created a parking lot with {totalSlots} slots");
                        break;

                    case "park":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot is not created");
                            break;
                        }
                        string regNumber = command[1];
                        string colour = command[2];
                        string type = command[3];
                        Vehicle vehicle = new Vehicle { RegistrationNumber = regNumber, Colour = colour, Type = type };
                        int slotNumber = parkingLot.ParkVehicle(vehicle);
                        if (slotNumber == -1)
                        {
                            Console.WriteLine("Sorry, parking lot is full");
                        }
                        else
                        {
                            Console.WriteLine($"Allocated slot number: {slotNumber}");
                        }
                        break;

                    case "leave":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot is not created");
                            break;
                        }
                        int slotToLeave = int.Parse(command[1]);
                        bool isLeft = parkingLot.LeaveVehicle(slotToLeave);
                        if (isLeft)
                        {
                            Console.WriteLine($"Slot number {slotToLeave} is free");
                        }
                        else
                        {
                            Console.WriteLine("Slot number is invalid");
                        }
                        break;

                    case "status":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot is not created");
                            break;
                        }
                        parkingLot.Status();
                        break;

                    case "type_of_vehicles":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot is not created");
                            break;
                        }
                        string vehicleType = command[1];
                        int count = parkingLot.GetVehicleCountByType(vehicleType);
                        Console.WriteLine(count);
                        break;

                    case "registration_numbers_for_vehicles_with_ood_plate":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot is not created");
                            break;
                        }
                        var oddNumbers = parkingLot.GetRegistrationNumbersByPlateType(true);
                        Console.WriteLine(string.Join(", ", oddNumbers));
                        break;

                    case "registration_numbers_for_vehicles_with_event_plate":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot is not created");
                            break;
                        }
                        var evenNumbers = parkingLot.GetRegistrationNumbersByPlateType(false);
                        Console.WriteLine(string.Join(", ", evenNumbers));
                        break;

                    case "registration_numbers_for_vehicles_with_colour":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot is not created");
                            break;
                        }
                        string searchColour = command[1];
                        var regNumbers = parkingLot.GetRegistrationNumbersByColour(searchColour);
                        Console.WriteLine(string.Join(", ", regNumbers));
                        break;

                    case "slot_numbers_for_vehicles_with_colour":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot is not created");
                            break;
                        }
                        string colourToSearch = command[1];
                        var slots = parkingLot.GetSlotsByColour(colourToSearch);
                        Console.WriteLine(string.Join(", ", slots));
                        break;

                    case "slot_number_for_registration_number":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot is not created");
                            break;
                        }
                        string registrationToSearch = command[1];
                        int foundSlot = parkingLot.GetSlotByRegistrationNumber(registrationToSearch);
                        if (foundSlot == -1)
                        {
                            Console.WriteLine("Not found");
                        }
                        else
                        {
                            Console.WriteLine(foundSlot);
                        }
                        break;

                    case "exit":
                        return;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}
