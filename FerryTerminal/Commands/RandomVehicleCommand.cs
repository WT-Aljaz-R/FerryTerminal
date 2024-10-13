using FerryTerminal.Models;
using FerryTerminal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FerryTerminal.Commands
{
    internal class RandomVehicleCommand : CommandBase
    {
        private Action<Vehicle> _setVehicleAction;
        private Action _updateViewAction;

        public RandomVehicleCommand(Action<Vehicle> setVehicle, Action updateView)
        {
            _setVehicleAction = setVehicle;
            _updateViewAction = updateView;
        }

        public override void Execute(object? parameter)
        {
            
            var random = new Random();
            var randomVehicleType = (VehicleType)random.Next(0, Enum.GetValues(typeof(VehicleType)).Length);
            int randomFuelLevel = random.Next(0, 101);  
                  
            Vehicle randomVehicle = new Vehicle(randomVehicleType, randomFuelLevel);

            _setVehicleAction?.Invoke(randomVehicle);
            _updateViewAction?.Invoke();
        }
    }
}
