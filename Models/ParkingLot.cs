using System;
using System.Collections.Generic;

namespace ParkingSystem
{
    public class Vehicle
    {
        public string RegistrationNumber { get; set; }
        public string Colour { get; set; }
        public string Type { get; set; }
    }

    public class ParkingLot
    {
        private int totalSlots;
        private Vehicle[] slots;

        public ParkingLot(int totalSlots)
        {
            this.totalSlots = totalSlots;
            this.slots = new Vehicle[totalSlots];
        }

        public int ParkVehicle(Vehicle vehicle)
        {
            for (int i = 0; i < totalSlots; i++)
            {
                if (slots[i] == null)
                {
                    slots[i] = vehicle;
                    return i + 1;
                }
            }
            return -1; // Parkir penuh
        }

        public bool LeaveVehicle(int slotNumber)
        {
            if (slotNumber > 0 && slotNumber <= totalSlots && slots[slotNumber - 1] != null)
            {
                slots[slotNumber - 1] = null;
                return true;
            }
            return false;
        }

        public void Status()
        {
            Console.WriteLine("Slot\tNo.\t\tType\tRegistration No\tColour");
            for (int i = 0; i < totalSlots; i++)
            {
                if (slots[i] != null)
                {
                    var vehicle = slots[i];
                    Console.WriteLine($"{i + 1}\t{vehicle.RegistrationNumber}\t{vehicle.Type}\t{vehicle.RegistrationNumber}\t{vehicle.Colour}");
                }
            }
        }

        public List<int> GetSlotsByColour(string colour)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < totalSlots; i++)
            {
                if (slots[i]?.Colour == colour)
                {
                    result.Add(i + 1);
                }
            }
            return result;
        }

        public int GetSlotByRegistrationNumber(string registrationNumber)
        {
            for (int i = 0; i < totalSlots; i++)
            {
                if (slots[i]?.RegistrationNumber == registrationNumber)
                {
                    return i + 1;
                }
            }
            return -1; // Tidak ditemukan
        }

        public List<string> GetRegistrationNumbersByColour(string colour)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < totalSlots; i++)
            {
                if (slots[i]?.Colour == colour)
                {
                    result.Add(slots[i].RegistrationNumber);
                }
            }
            return result;
        }

        public List<string> GetRegistrationNumbersByPlateType(bool isOdd)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < totalSlots; i++)
            {
                if (slots[i] != null)
                {
                    string regNumber = slots[i].RegistrationNumber;
                    // Mengambil angka dari nomor polisi
                    string[] parts = regNumber.Split('-');
                    if (parts.Length > 1)
                    {
                        int numberPart;
                        if (int.TryParse(parts[1], out numberPart))
                        {
                            // Menentukan ganjil/genap berdasarkan angka terakhir
                            if ((numberPart % 2 == 1) == isOdd)
                            {
                                result.Add(regNumber);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public int GetVehicleCountByType(string type)
        {
            int count = 0;
            for (int i = 0; i < totalSlots; i++)
            {
                if (slots[i]?.Type == type)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
