using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Restaurant_API_SP.DAL;
using System.Data;

namespace Restaurant_API_SP.Repository
{
    public class RoomRepository
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Room details
        public bool AddRoom(Room obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddNewRoom", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@RoomID", obj.RoomID);
            com.Parameters.AddWithValue("@RoomName", obj.RoomName);
            com.Parameters.AddWithValue("@Capacity", obj.Capacity);
            com.Parameters.AddWithValue("@RemainingSpace", obj.RemainingSpace);
            com.Parameters.AddWithValue("@Description", obj.Description);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        //To view Room details with generic list 
        public List<Room> GetAllRooms()
        {
            connection();
            List<Room> RoomList = new List<Room>();
            SqlCommand com = new SqlCommand("GetAllRooms", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind Room generic list using LINQ 
            RoomList = (from DataRow dr in dt.Rows

                        select new Room()
                        {
                            RoomID = Convert.ToInt32(dr["RoomID"]),
                            RoomName = Convert.ToString(dr["RoomName"]),
                            Capacity = Convert.ToInt32(dr["Capacity"]),
                            RemainingSpace = Convert.ToInt32(dr["RemainingSpace"]),
                            Description = Convert.ToString(dr["Description"])
                        }).ToList();


            return RoomList;


        }
        //To Update Room details
        public bool UpdateRoom(Room obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateRoom", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@RoomID", obj.RoomID);
            com.Parameters.AddWithValue("@RoomName", obj.RoomName);
            com.Parameters.AddWithValue("@Capacity", obj.Capacity);
            com.Parameters.AddWithValue("@RemainingSpace", obj.RemainingSpace);
            com.Parameters.AddWithValue("@Description", obj.Description);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool DeleteRoom(int Id)
        {
            connection();
            SqlCommand comDeleteRoom = new SqlCommand("DeleteRoom", con);
            comDeleteRoom.CommandType = CommandType.StoredProcedure;
            comDeleteRoom.Parameters.AddWithValue("@RoomID", Id);

            try
            {
                con.Open();

                // Delete associated booking records
                SqlCommand comDeleteBooking = new SqlCommand("DeleteBooking", con);
                comDeleteBooking.CommandType = CommandType.StoredProcedure;
                comDeleteBooking.Parameters.AddWithValue("@BookingID", Id);
                comDeleteBooking.ExecuteNonQuery();

                // Delete associated user records
                SqlCommand comDeleteUser = new SqlCommand("DeleteUser", con);
                comDeleteUser.CommandType = CommandType.StoredProcedure;
                comDeleteUser.Parameters.AddWithValue("@UserID", Id);
                comDeleteUser.ExecuteNonQuery();

                // Finally, delete the room
                int i = comDeleteRoom.ExecuteNonQuery();

                con.Close();

                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                // Handle exceptions
                throw;
            }
        }


        //To delete Room details
        //public bool DeleteRoom(int Id)
        //{

        //    connection();
        //    SqlCommand com = new SqlCommand("DeleteRoom", con);

        //    com.CommandType = CommandType.StoredProcedure;
        //    com.Parameters.AddWithValue("@RoomID", Id);

        //    SqlCommand deleteBookingsCmd = new SqlCommand("DELETE FROM Booking WHERE BookingID = @BookingID", con);
        //    deleteBookingsCmd.Parameters.AddWithValue("@BookingID", Id);
        //    deleteBookingsCmd.ExecuteNonQuery();

        //    // Delete associated user records
        //    SqlCommand deleteUsersCmd = new SqlCommand("DELETE FROM [User] WHERE UserID = @UserID", con);
        //    deleteUsersCmd.Parameters.AddWithValue("@UserID", Id);
        //    deleteUsersCmd.ExecuteNonQuery();
        //    con.Open();
        //    int i = com.ExecuteNonQuery();
        //    con.Close();
        //    if (i >= 1)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }


    }
}
