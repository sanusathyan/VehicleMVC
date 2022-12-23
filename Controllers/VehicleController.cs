using Microsoft.AspNetCore.Mvc;
using VehicleMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleMVC.Controllers;
using VehicleMVC.VehicleRepository;

namespace VehicleMVC.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult GetVehicles()
        {
            var vechicleRepository = new VehRepository();
            var vehicle = vechicleRepository.GetVechicles();
            return View(vehicle);
        }

        public IActionResult GetVehicleById(int id)
        {
            var vechicleRepository = new VehRepository();
            var vehicle = vechicleRepository.GetVehicleById(id);
            return View(vehicle);
        }

        public IActionResult CreateVehicles(int id)
        {
            var vechicleRepository = new VehRepository();
            var vehicle = vechicleRepository.GetVehicleById(id);
            return View(vehicle);
        }

        [HttpPost]
        public IActionResult CreateVehicles(Vehicle vehicle)
        {
            var vechicleRepository = new VehRepository();
            vechicleRepository.InsertvehicleList(vehicle);
            return View();
        }

        public IActionResult EditVehicles(int id)
        {
            var vechicleRepository = new VehRepository();
            var vehicle = vechicleRepository.GetVehicleById(id);
            return View(vehicle);
        }

        [HttpPost]
        public IActionResult EditVehicles(Vehicle vehicle)
        {
            var vechicleRepository = new VehRepository();
            vechicleRepository.Updatevehicle(vehicle);
            return View();
        }

        public IActionResult DeleteVehicles(int id)
        {
            var vechicleRepository = new VehRepository();
            var vehicle = vechicleRepository.GetVehicleById(id);
            return View(vehicle);
        }

        [HttpPost]
        public IActionResult DeleteVehicles(Vehicle vehicle)
        {
            var vechicleRepository = new VehRepository();
            vechicleRepository.Deletevehicle(vehicle.Id);
            return View();
        }
    }
}
