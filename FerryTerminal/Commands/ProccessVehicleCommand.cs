using FerryTerminal.Models;
using FerryTerminal.Services;
using FerryTerminal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal.Commands
{
    internal class ProccessVehicleCommand : CommandBase
    {

        private Func<Vehicle> _getVehicleAction;
        private readonly Ferry[] _ferries;
        private readonly TerminalService _terminalService;
        private readonly Profits _profits;
        private Action _updateViewAction;


        public ProccessVehicleCommand(Func<Vehicle> getVehicle, Profits profits, Ferry[] ferries, Action UpdateView) {

            _terminalService = new TerminalService();
            _getVehicleAction = getVehicle;
            _profits = profits;
            _ferries = ferries;
            _updateViewAction = UpdateView;
       
        }

        public async override void Execute(object? parameter)
        {
            Vehicle vehicle = _getVehicleAction();

            await _terminalService.ProccessVehicle(vehicle, _profits, _ferries, _updateViewAction);
        }

    }
}
