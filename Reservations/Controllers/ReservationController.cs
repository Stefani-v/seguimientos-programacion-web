using Microsoft.AspNetCore.Mvc;
using Reservations.Models;

namespace Reservations.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View(ReservationData.Services);
        }

        public IActionResult Book(int id)
        {
            var service = ReservationData.Services.FirstOrDefault(s => s.Id == id);
            if (service == null) return RedirectToAction("Index");

            ViewBag.Service = service;
            ViewBag.AvailableSlots = ReservationData.AvailableSlots;
            return View();
        }

        [HttpPost]
        public IActionResult Book(int serviceId, string clientName, string clientEmail, DateTime date, string timeSlot)
        {
            if (string.IsNullOrWhiteSpace(clientName) || string.IsNullOrWhiteSpace(clientEmail))
                return RedirectToAction("Book", new { id = serviceId });

            var reservation = new Reservation
            {
                Id = ReservationData.Reservations.Count + 1,
                ServiceId = serviceId,
                ClientName = clientName,
                ClientEmail = clientEmail,
                Date = date,
                TimeSlot = timeSlot,
                Confirmed = false
            };

            ReservationData.Reservations.Add(reservation);
            return RedirectToAction("Confirmation", new { id = reservation.Id });
        }

        public IActionResult Confirmation(int id)
        {
            var reservation = ReservationData.Reservations.FirstOrDefault(r => r.Id == id);
            if (reservation == null) return RedirectToAction("Index");

            var service = ReservationData.Services.FirstOrDefault(s => s.Id == reservation.ServiceId);
            ViewBag.Service = service;
            return View(reservation);
        }

        [HttpPost]
        public IActionResult Confirm(int id)
        {
            var reservation = ReservationData.Reservations.FirstOrDefault(r => r.Id == id);
            if (reservation != null)
            {
                reservation.Confirmed = true;
            }
            return RedirectToAction("MyReservations");
        }

        public IActionResult MyReservations()
        {
            return View(ReservationData.Reservations.OrderByDescending(r => r.Date));
        }

        [HttpPost]
        public IActionResult Cancel(int id)
        {
            var reservation = ReservationData.Reservations.FirstOrDefault(r => r.Id == id);
            if (reservation != null)
            {
                ReservationData.Reservations.Remove(reservation);
            }
            return RedirectToAction("MyReservations");
        }

        public IActionResult CheckAvailability(int serviceId, DateTime date)
        {
            var booked = ReservationData.Reservations
                .Where(r => r.ServiceId == serviceId && r.Date.Date == date.Date)
                .Select(r => r.TimeSlot)
                .ToList();

            var available = ReservationData.AvailableSlots.Except(booked).ToList();
            return Json(available);
        }
    }
}