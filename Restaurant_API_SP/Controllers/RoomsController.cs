using System.Collections.Generic;
using System.Web.Http;
using Restaurant_API_SP.DAL;
using Restaurant_API_SP.Repository;

namespace Restaurant_API_SP.Controllers
{
    public class RoomController : ApiController
    {
        private RoomRepository roomRepository;

        public RoomController()
        {
            roomRepository = new RoomRepository();
        }

        // GET: api/room
        [HttpGet]
        public IHttpActionResult GetAllRooms()
        {
            List<Room> rooms = roomRepository.GetAllRooms();
            return Ok(rooms);
        }

        // POST: api/room
        [HttpPost]
        public IHttpActionResult AddRoom(Room room)
        {
            if (roomRepository.AddRoom(room))
            {
                return Ok("Room added successfully");
            }
            else
            {
                return BadRequest("Failed to add room");
            }
        }

        // PUT: api/room/5
        [HttpPut]
        public IHttpActionResult UpdateRoom(Room room)
        {
            if (roomRepository.UpdateRoom(room))
            {
                return Ok("Room updated successfully");
            }
            else
            {
                return BadRequest("Failed to update room");
            }
        }

        // DELETE: api/room/5
        [HttpDelete]
        public IHttpActionResult DeleteRoom(int id)
        {
            if (roomRepository.DeleteRoom(id))
            {
                return Ok("Room deleted successfully");
            }
            else
            {
                return BadRequest("Failed to delete room");
            }
        }
    }
}
