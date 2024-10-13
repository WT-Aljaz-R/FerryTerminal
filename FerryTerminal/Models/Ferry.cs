using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal.Models
{
    enum FerryType
    {
        FerryS,
        FerryL
    }
    internal class Ferry
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public FerryType  Type { get; set; }

        public VehicleType[] AllowedVehicles { get;}

        public int Capacity { get;}

        public ObservableCollection<Vehicle>  Vehicles { get;}

        public Ferry(FerryType type) {  
            Type = type; 
            

            if (type == FerryType.FerryS)
            {
                AllowedVehicles = new VehicleType[] { VehicleType.Car, VehicleType.Van };
                Capacity = 8;
                Vehicles = new ObservableCollection<Vehicle>();
            }
            else
            {
                AllowedVehicles = new VehicleType[] { VehicleType.Bus, VehicleType.Truck };
                Capacity = 6;
                Vehicles = new ObservableCollection<Vehicle>();
            }
        }

        public bool TryAddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Count < Capacity)
            {
                Vehicles.Add(vehicle);
                OnPropertyChanged(nameof(Vehicles)); 
                return true;
            }
            else
            {
                Console.WriteLine($"Ferry {Type} is full. Cannot add vehicle.");
                return false;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
