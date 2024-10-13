using FerryTerminal.Commands;
using FerryTerminal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FerryTerminal.ViewModels
{
    internal class TerminalViewModel : ViewModelBase
    {
        private Vehicle _vehicle;
        private Profits _profits;
        private ObservableCollection<Ferry> _ferries;

        public string Type => _vehicle.Type.ToString();
        public string Location => _vehicle.Location.ToString();
        public int FuelLevel => _vehicle.FuelLevel;
        public string DoorOpen => _vehicle.DoorOpen ? "Open" : "Closed";
        public int TotalProfits => _profits.TotalProfits;
        public double WorkerProfits => _profits.WorkerProfits;

        public double VehicleX => _vehicle.X;  
        public double VehicleY => _vehicle.Y;  

        public ICommand NextCommand { get; }
        public ICommand StartCommand { get; }

        public ObservableCollection<Ferry> Ferries => _ferries;

        public TerminalViewModel()
        {
            _profits = new Profits();
            _ferries = new ObservableCollection<Ferry>
            {
                new Ferry(FerryType.FerryS),
                new Ferry(FerryType.FerryL)
            };
            _vehicle = GenerateRandomVehicleOnStartup();

            NextCommand = new RandomVehicleCommand(SetRandomVehicle, UpdateView);
            StartCommand = new ProccessVehicleCommand(() => _vehicle, _profits, _ferries.ToArray(), UpdateView);

            _vehicle.PropertyChanged += (sender, e) => UpdateView();
            _ferries[0].PropertyChanged += (sender, e) => UpdateView();
            _ferries[1].PropertyChanged += (sender, e) => UpdateView();
        }

        private void UpdateView()
        {
            OnPropertyChanged(nameof(Type));
            OnPropertyChanged(nameof(Location));
            OnPropertyChanged(nameof(FuelLevel));
            OnPropertyChanged(nameof(DoorOpen));
            OnPropertyChanged(nameof(TotalProfits));
            OnPropertyChanged(nameof(WorkerProfits));
            OnPropertyChanged(nameof(VehicleX));  
            OnPropertyChanged(nameof(VehicleY));
            OnPropertyChanged(nameof(Ferries));
        }

        private void SetRandomVehicle(Vehicle vehicle)
        {
            _vehicle = vehicle;

            _vehicle.PropertyChanged += (sender, e) => UpdateView();

            UpdateView();
        }

        private Vehicle GenerateRandomVehicleOnStartup()
        {
            var random = new Random();
            var randomVehicleType = (VehicleType)random.Next(0, Enum.GetValues(typeof(VehicleType)).Length);
            int randomFuelLevel = random.Next(0, 101);

            return new Vehicle(randomVehicleType, randomFuelLevel);
        }
    }

}

