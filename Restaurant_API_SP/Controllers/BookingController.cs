using System.Collections.Generic;
using System.Web.Http;
using Restaurant_API_SP.DAL;
using Restaurant_API_SP.Repository;


namespace Restaurant_API_SP.Controllers
{
    public class BookingController : ApiController
    {
        // GET: Booking
        private BookingRepository BookingRepository;

        public BookingController()
        {
            BookingRepository = new BookingRepository();
        }

        // GET: api/Booking
        [HttpGet]
        public IHttpActionResult GetAllBookings()
        {
            List<Booking> Bookings = BookingRepository.GetAllBookings();
            return Ok(Bookings);
        }

        // POST: api/Booking
        [HttpPost]
        public IHttpActionResult AddBooking(Booking Booking)
        {
            if (BookingRepository.AddBooking(Booking))
            {
                return Ok("Booking added successfully");
            }
            else
            {
                return BadRequest("Failed to add Booking");
            }
        }

        // PUT: api/Booking/5
        [HttpPut]
        public IHttpActionResult UpdateBooking(Booking Booking)
        {
            if (BookingRepository.UpdateBooking(Booking))
            {
                return Ok("Booking updated successfully");
            }
            else
            {
                return BadRequest("Failed to update Booking");
            }
        }

        // DELETE: api/Booking/5
        [HttpDelete]
        public IHttpActionResult DeleteBooking(int id)
        {
            if (BookingRepository.DeleteBooking(id))
            {
                return Ok("Booking deleted successfully");
            }
            else
            {
                return BadRequest("Failed to delete Booking");
            }
        }
    }
}