using Microsoft.AspNetCore.Mvc;
using TennisCourtMembershipSoft.Models;
using System.Data.SqlClient;
using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using System.Xml.Schema;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace TennisCourtMembershipSoft.Controllers
{
    public class AdminController : Controller
    {
        DBContext DB = new DBContext();
        AccountController Login = new AccountController();

        public IActionResult Index()
        {
            return View();
        }
        // GET: Admin/ViewMembers
        public IActionResult ViewMemberships()
        {
            // Implement code for viewing all members
            var sch = new List<Schedules>();
            string cmd = "SELECT E.EnrollId , E.ScheduleId , E.MemberId , C.FirstName AS FN1 , " +
                         "C.LastName AS LN1 , M.FirstName AS FN2 , M.LastName AS LN2 , S.EventName , " +
                         "S.Date , S.Location , S.CoachId " +
                         "FROM Enrollments E LEFT JOIN Schedules S ON E.ScheduleId = S.ScheduleId LEFT JOIN " +
                         "Members M ON E.MemberId = M.MemberId LEFT JOIN Coaches C ON S.CoachId = C.CoachId; " ;
            CultureInfo provider = CultureInfo.InvariantCulture;
            DB.Connection.Open();
            DB.Command = new SqlCommand(cmd,DB.Connection);
            DB.Reader = DB.Command.ExecuteReader();
            while(DB.Reader.Read())
            {
                if (DB.Reader["MemberId"].ToString() != "")
                {
                    var id = Schedules.CoachId;
                    Schedules schd = new Schedules();
                    schd.EventName = DB.Reader["EventName"].ToString();
                    schd.Location = DB.Reader["Location"].ToString();
                    id = Int32.Parse(DB.Reader["CoachId"].ToString());
                    Schedules.CoachId = id;

                    schd.MemberId = Int32.Parse(DB.Reader["MemberId"].ToString());
                    Schedules.ScheduleId = Int32.Parse(DB.Reader["ScheduleId"].ToString());
                    //DateTime.ParseExact(DB.Reader["Date"].ToString(), "d",provider);
                    schd.Coach = new Coach();
                    schd.Member = new Members();
                    schd.Coach.FirstName = DB.Reader["FN1"].ToString();
                    schd.Coach.LastName = DB.Reader["LN1"].ToString();
                    schd.Member.FirstName = DB.Reader["FN2"].ToString();
                    schd.Member.LastName = DB.Reader["LN2"].ToString();
                    sch.Add(schd);
                }
            }
            DB.Reader.Close();
            DB.Connection.Close();
            return View(sch);
        }

        // GET: Admin/MatchCoach
        public IActionResult MatchCoach()
        {
            // Implement code for matching coaches with schedules
            var sch = new Schedules();
            string cmd = "SELECT S.ScheduleId , C.CoachId " +
                         "FROM Schedules S , Coaches C ;";
            DB.Connection.Open();
            DB.Command = new SqlCommand(cmd, DB.Connection);
            DB.Reader = DB.Command.ExecuteReader();
            var id1 = new List<int>();
            var id2 = new List<int>();
            while (DB.Reader.Read())
            {
                //var schd = new Schedules();
                id1.Add(Int32.Parse(DB.Reader["ScheduleId"].ToString()));
                id2.Add(Int32.Parse(DB.Reader["CoachId"].ToString()));
                
                //Schedules.CoachesIds.Append((Int32.Parse(DB.Reader["CoachId"].ToString())));   
                    //sch.Coach = new Coach();
                    //sch.Coach.CoachId = Int32.Parse(DB.Reader["CoachId"].ToString());
            }
            var list1 = new List<int>();
            var list2 = new List<int>();
            list1 = id1.Distinct().ToList();
            list2 = id2.Distinct().ToList();
            List<SelectListItem> scheduleItems = list1
                .Select(id => new SelectListItem { Value = id.ToString(), Text = id.ToString() })
                .ToList();
            List<SelectListItem> CoachItems = list2
                .Select(id => new SelectListItem { Value = id.ToString(), Text = id.ToString() })
                .ToList();
            ViewData["ScheduleIds"] = scheduleItems;
            ViewData["CoachIds"] = CoachItems;
            DB.Reader.Close();
            DB.Connection.Close();
            return View(sch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MatchCoach(Schedules sch)
        {

            // Implement logic for matching coaches with schedules
            string cmd = "UPDATE Schedules SET CoachId = @id2 " +
                         "WHERE ScheduleId = @id1 ;";
            DB.Connection.Open();
            DB.Command = new SqlCommand(cmd, DB.Connection);
            DB.Command.Parameters.AddWithValue("@id1", sch.id1);
            DB.Command.Parameters.AddWithValue("@id2", sch.id2);
            DB.Command.ExecuteNonQuery();
            DB.Connection.Close();
            // Redirect to appropriate views based on matching result
            return View("Index");
        }

        public IActionResult CreateSchedule()
        {
            var sch = new Schedules();
            string cmd = "SELECT CoachId " +
                         "FROM Coaches ;";
            DB.Connection.Open();
            DB.Command = new SqlCommand(cmd, DB.Connection);
            DB.Reader = DB.Command.ExecuteReader();
            var id2 = new List<int>();
            while (DB.Reader.Read())
            {
                id2.Add(Int32.Parse(DB.Reader["CoachId"].ToString()));
            }
            var list2 = new List<int>();
            list2 = id2.Distinct().ToList();

            List<SelectListItem> CoachItems = list2
                .Select(id => new SelectListItem { Value = id.ToString(), Text = id.ToString() })
                .ToList();
            ViewData["CoachIds"] = CoachItems;
            DB.Reader.Close();
            DB.Connection.Close();
            return View(sch);
        }

        [HttpPost]
        public IActionResult CreateSchedule(Schedules ch)
        {
            string cmd = "INSERT INTO Schedules (EventName , Date , Location , CoachId) " +
                         "VALUES (@event , @date , @loc , @coach) ;";
            DB.Connection.Open();
            DB.Command = new SqlCommand(cmd, DB.Connection);
            DB.Command.Parameters.AddWithValue("@event", ch.EventName);
            DB.Command.Parameters.AddWithValue("@date", ch.Date);
            DB.Command.Parameters.AddWithValue("@loc", ch.Location);
            DB.Command.Parameters.AddWithValue("@coach", ch.id2);
            DB.Command.ExecuteNonQuery();
            DB.Connection.Close();
            return View("Index");
        }

        public IActionResult LogOut()
        {
            return RedirectToAction("AdminLogin" , "Account");
        }

    }
}
