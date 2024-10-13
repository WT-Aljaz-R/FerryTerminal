using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal.Models
{
    enum VehicleType
    {
        Car,
        Van,
        Bus,
        Truck
    }

    enum VehicleLocation
    {
        FerryS,
        FerryL,
        GasStation,
        Customs,
        Entrance
    }

    

    internal class Vehicle: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private VehicleLocation _location;
        private int _fuelLevel;
        public VehicleType Type { get; set; }
        public VehicleLocation Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
                UpdatePosition(); 
            }
        }

        public int TickerPrice { get;}

        public int FuelLevel
        {
            get => _fuelLevel;
            set
            {
                if (value < 0)
                {
                    _fuelLevel = 0;
                }
                else if (value > 100)
                {
                    _fuelLevel = 100;
                }
                else
                {
                    _fuelLevel = value;
                }
                OnPropertyChanged(nameof(FuelLevel));
            }
        }

        public bool CustomsCheck { get; }

        public bool DoorOpen { get; set; }

        public double X { get; private set; }
        public double Y { get; private set; }

        public Vehicle(VehicleType type, int fuelLevel)
        {
            Type = type;
            Location = VehicleLocation.Entrance;
            FuelLevel = fuelLevel;
            DoorOpen = false;
            UpdatePosition();

            switch (type)
            {
                case VehicleType.Car:
                    TickerPrice = 3;
                    CustomsCheck = false;
                    break;
                case VehicleType.Van:
                    TickerPrice = 4;
                    CustomsCheck = true;
                    break;
                case VehicleType.Bus:
                    TickerPrice = 5;
                    CustomsCheck = false;
                    break;
                case VehicleType.Truck:
                    TickerPrice = 6;
                    CustomsCheck = true;
                    break;
            }
        }

        private void UpdatePosition()
        {
            switch (Location)
            {
                case VehicleLocation.Entrance:
                    X = 125; Y = 10;
                    break;
                case VehicleLocation.GasStation:
                    X = 30; Y = 80;
                    break;
                case VehicleLocation.FerryS:
                    X = 200; Y = 80;
                    break;
                case VehicleLocation.Customs:
                    X = 30; Y = 180;
                    break;
                case VehicleLocation.FerryL:
                    X = 200; Y = 180;
                    break;
            }

            OnPropertyChanged(nameof(X));
            OnPropertyChanged(nameof(Y));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
