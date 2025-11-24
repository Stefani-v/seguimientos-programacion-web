using Microsoft.AspNetCore.Mvc;
using Reservations.Models;

namespace Reservations.Controllers
{
    public class ReservationController: Controller
    {
        private static List<Reservation> _reservations = new();
        private static int _idCounter = 1;

        private readonly List<string> _timeSlots = new()
        {
            "09:00 AM", "10:00 AM", "11:00 AM",
            "01:00 PM", "02:00 PM", "03:00 PM",
            "04:00 PM"
        };

        public IActionResult Index()
        {
            var vm = new ReservationView
            {
                Reservations = _reservations,
                TimeSlots = _timeSlots
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Reserve(ReservationView vm)
        {
            vm.NewReservation.Id = _idCounter++;

            // Check if timeslot is already booked
            bool taken = _reservations.Any(b =>
                b.Date.Date == vm.NewReservation.Date.Date &&
                b.TimeSlot == vm.NewReservation.TimeSlot);

            if (taken)
            {
                ModelState.AddModelError("", "This timeslot is already booked.");

                vm.Reservations = _reservations;
                vm.TimeSlots = _timeSlots;

                return View("Index", vm);
            }

            _reservations.Add(vm.NewReservation);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var booking = _reservations.FirstOrDefault(b => b.Id == id);
            if (booking != null)
                _reservations.Remove(booking);

            return RedirectToAction("Index");
        }
    }
}

