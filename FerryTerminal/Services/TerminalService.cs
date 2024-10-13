using FerryTerminal.Models;
using FerryTerminal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal.Services
{
    internal class TerminalService
    {
        public async Task ProccessVehicle(Vehicle vehicle, Profits profits, Ferry[] ferries, Action UpdateView)
        {
            profits.TotalProfits += vehicle.TickerPrice;
            profits.WorkerProfits += vehicle.TickerPrice * 0.1;

            await Task.Delay(2000);

            if (vehicle.CustomsCheck)
            {
                vehicle.Location = VehicleLocation.Customs;
                await Task.Delay(2000);
            }


            if (vehicle.Location == VehicleLocation.Customs)
            {
                vehicle.DoorOpen = true;
                await Task.Delay(2000);
            }


            if (vehicle.FuelLevel < 10)
            {
                vehicle.Location = VehicleLocation.GasStation;
                vehicle.FuelLevel = 100;
                await Task.Delay(2000);
            }




            foreach (Ferry ferry in ferries)
            {
                if (ferry.AllowedVehicles.Contains(vehicle.Type))
                {
                    if (ferry.TryAddVehicle(vehicle))
                    {
                        vehicle.Location = ferry.Type == FerryType.FerryS ? VehicleLocation.FerryS : VehicleLocation.FerryL;
                        UpdateView();
                    }
                    else
                    {
                     
                        Console.WriteLine($"{ferry.Type} is full. Cannot add vehicle.");
                    }
                }
            }

        }
    }
}
