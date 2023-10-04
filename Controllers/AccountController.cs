using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TennisCourtMembershipSoft.Models;

namespace TennisCourtMembershipSoft.Controllers
{
    public class AccountController : Controller
    {
        public DBContext DB = new DBContext();
        public int userid = 0;
        public IActionResult AdminLogin()
        {
            string str = "";
            str = "Update Admins " +
                  "SET LoginStatus = 0 " +
                  "WHERE LoginStatus = 1 ;";
            DB.Connection.Open();
            DB.Command = new SqlCommand(str, DB.Connection);
            DB.Command.ExecuteNonQuery();
            DB.Connection.Close();
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(Admin admin)
        {
            string str = "";
            str = "SELECT * FROM Admins WHERE Email = @email and PasswordHash = @password";
            DB.Connection.Open();
            DB.Command = new SqlCommand(str, DB.Connection);
            DB.Command.Parameters.AddWithValue("@email", admin.Email);
            DB.Command.Parameters.AddWithValue("@password", admin.PasswordHash);
            DB.Reader = DB.Command.ExecuteReader();
            DB.Reader.Read();
            if (DB.Reader.HasRows)
            {
                DB.Connection.Close();
                DB.Reader.Close();

                str = "UPDATE Admins SET LoginStatus = 1 " +
                      "WHERE Email = @email and PasswordHash = @password ;";
                DB.Connection.Open();
                DB.Command = new SqlCommand(str, DB.Connection);
                DB.Command.Parameters.AddWithValue("@email", admin.Email);
                DB.Command.Parameters.AddWithValue("@password", admin.PasswordHash);
                DB.Command.ExecuteNonQuery();
                DB.Connection.Close();

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                DB.Connection.Close();
                DB.Reader.Close();
                TempData["Message"] = "Invalid Username or Password";
                return View();
            }
        }
        public IActionResult CoachLogin()
        {
            string str = "";
            str = "Update Coaches " +
                  "SET LoginStatus = 0 " +
                  "WHERE LoginStatus = 1 ;";
            DB.Connection.Open();
            DB.Command = new SqlCommand(str, DB.Connection);
            DB.Command.ExecuteNonQuery();
            DB.Connection.Close();
            return View();
        }

        [HttpPost]
        public IActionResult CoachLogin(Coach coach)
        {
            string str = "";
            str = "SELECT * FROM Coaches WHERE Email = @email and PasswordHash = @password";
            DB.Connection.Open();
            DB.Command = new SqlCommand(str, DB.Connection);
            DB.Command.Parameters.AddWithValue("@email", coach.Email);
            DB.Command.Parameters.AddWithValue("@password", coach.PasswordHash);
            DB.Reader = DB.Command.ExecuteReader();
            DB.Reader.Read();
            if (DB.Reader.HasRows)
            {
                DB.Connection.Close();
                DB.Reader.Close();

                str = "UPDATE Coaches SET LoginStatus = 1 " +
                      "WHERE Email = @email and PasswordHash = @password ;";
                DB.Connection.Open();
                DB.Command = new SqlCommand(str, DB.Connection);
                DB.Command.Parameters.AddWithValue("@email", coach.Email);
                DB.Command.Parameters.AddWithValue("@password", coach.PasswordHash);
                DB.Command.ExecuteNonQuery();
                DB.Connection.Close();

                return RedirectToAction("Index", "Coach");
            }
            else
            {
                DB.Connection.Close();
                DB.Reader.Close();
                TempData["Message"] = "Invalid Username or Password";
                return View();
            }
        }
        public IActionResult MemberLogin()
        {
            string str = "";
            str = "Update Members " +
                  "SET LoginStatus = 0 " +
                  "WHERE LoginStatus = 1 ;";
            DB.Connection.Open();
            DB.Command = new SqlCommand(str, DB.Connection);
            DB.Command.ExecuteNonQuery();
            DB.Connection.Close();
            return View();
        }

        [HttpPost]
        public IActionResult MemberLogin(Members member)
        {
            string str = "";
            str = "SELECT * FROM Members WHERE Email = @email and PasswordHash = @password";
            DB.Connection.Open();
            DB.Command = new SqlCommand(str, DB.Connection);
            DB.Command.Parameters.AddWithValue("@email", member.Email);
            DB.Command.Parameters.AddWithValue("@password", member.PasswordHash);
            DB.Reader = DB.Command.ExecuteReader();
            DB.Reader.Read();
            if (DB.Reader.HasRows)
            {
                DB.Connection.Close();
                DB.Reader.Close();

                str = "UPDATE Members SET LoginStatus = 1 " +
                      "WHERE Email = @email and PasswordHash = @password ;";
                DB.Connection.Open();
                DB.Command = new SqlCommand(str, DB.Connection);
                DB.Command.Parameters.AddWithValue("@email", member.Email);
                DB.Command.Parameters.AddWithValue("@password", member.PasswordHash);
                DB.Command.ExecuteNonQuery();
                DB.Connection.Close();

                return RedirectToAction("Index", "Members");
            }
            else
            {
                DB.Connection.Close();
                DB.Reader.Close();
                TempData["Message"] = "Invalid Username or Password";
                return View();
            }
        }
        public IActionResult CoachRegister()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CoachRegister(Coach model)
        {
            string str = "INSERT INTO Coaches (Email, PasswordHash) " +
                         "VALUES (@Email, @Password)";
            DB.Connection.Open();
            DB.Command = new SqlCommand(str, DB.Connection);

            DB.Command.Parameters.AddWithValue("@Email", model.Email);
            DB.Command.Parameters.AddWithValue("@Password", model.PasswordHash);
            DB.Command.ExecuteNonQuery();

            DB.Connection.Close();

            return RedirectToAction("CoachLogin");
        }
        public IActionResult MemberRegister()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MemberRegister(Members model)
        {
            string str = "INSERT INTO Members (Email, PasswordHash) " +
                         "VALUES (@Email, @Password)";
            DB.Connection.Open();
            DB.Command = new SqlCommand(str, DB.Connection);

            DB.Command.Parameters.AddWithValue("@Email", model.Email);
            DB.Command.Parameters.AddWithValue("@Password", model.PasswordHash);
            DB.Command.ExecuteNonQuery();

            DB.Connection.Close();

            return RedirectToAction("MemberLogin");
        }
        public IActionResult AdminRegister()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminRegister(Admin model)
        {
            string str = "INSERT INTO Admins (Email, PasswordHash) " +
                         "VALUES (@Email, @Password)";
            DB.Connection.Open();
            DB.Command = new SqlCommand(str, DB.Connection);

            DB.Command.Parameters.AddWithValue("@Email", model.Email);
            DB.Command.Parameters.AddWithValue("@Password", model.PasswordHash);
            DB.Command.ExecuteNonQuery();

            DB.Connection.Close();

            return RedirectToAction("AdminLogin");
        }

        public int ActiveAdmin()
        {
            string str = "SELECT * FROM Admins WHERE " +
                         "LoginStatus = 1 ;";
            DB.Connection.Open();
            DB.Command = new SqlCommand(str, DB.Connection);
            DB.Reader = DB.Command.ExecuteReader();
            DB.Reader.Read();
            userid = Int32.Parse(DB.Reader["AdminId"].ToString());
            DB.Connection.Close();
            DB.Reader.Close();
            return userid;
        }

        public int ActiveCoach()
        {
            string str = "SELECT * FROM Coaches WHERE " +
                         "LoginStatus = 1 ;";
            DB.Connection.Open();
            DB.Command = new SqlCommand(str, DB.Connection);
            DB.Reader = DB.Command.ExecuteReader();
            DB.Reader.Read();
            userid = Int32.Parse(DB.Reader["CoachId"].ToString());
            DB.Connection.Close();
            DB.Reader.Close();
            return userid;
        }

        public int ActiveMember()
        {
            string str = "SELECT * FROM Members WHERE " +
                         "LoginStatus = 1 ;";
            DB.Connection.Open();
            DB.Command = new SqlCommand(str, DB.Connection);
            DB.Reader = DB.Command.ExecuteReader();
            DB.Reader.Read();
            userid = Int32.Parse(DB.Reader["MemberId"].ToString());
            DB.Connection.Close();
            DB.Reader.Close();
            return userid;
        }
    }
}
