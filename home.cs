using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChildSearchAssgn.Models;

namespace ChildSearchAssgn.Controllers
{
    public class HomeController : Controller
    {

        public class childNewList
        {
            public string childName { get; set; }
            public int childId { get; set; }
            public int schoolId { get; set; }
            public string schoolName { get; set; }
        }
        

        public ActionResult Index()
        {
            //TaxInfoEntities contect = new TaxInfoEntities();
            ChildDetailsEntities contect = new ChildDetailsEntities();
            var obj = contect.Children.Join(contect.Schools, r => r.SchoolId, p => p.Id, (r, p) => new { Child = r, School = p });
            childNewList childFetchItem;
            List<childNewList> chdList = new List<childNewList>();
            
            if (obj != null)
            {
                foreach (var data1 in obj)
                {
                    childFetchItem = new childNewList();
                    childFetchItem.childName = data1.Child.Name;
                    childFetchItem.childId = data1.Child.Id;
                    childFetchItem.schoolId = Convert.ToInt32(data1.Child.SchoolId);
                    childFetchItem.schoolName = data1.School.Name;
                    chdList.Add(childFetchItem);

                }
            }


            // ViewBag.SchoolsList = contect.Schools.Select(x => new { schoolName = x.Name, schoolId = x.Id });
            var obj4 = (from c in contect.Schools
                        select new SchoolDetails()
                        {
                            schName = c.Name,
                            schID = c.Id
                        }).ToList();
            ViewBag.SchoolsList = obj4;







            
           // List<childNewList> schoolList = new List<childNewList>();
           // childNewList schFetchItem;
            //if (obj4 != null)
            //{
            //    foreach (var data5 in obj4)
            //    {
            //        schFetchItem = new childNewList();
            //        //onlySchoolList.schoolId = Convert.ToInt32(data5.Schoo);
            //        schFetchItem.schoolName = data5;
            //        schoolList.Add(schFetchItem);

            //    }
            //}
           // ViewBag.Funds = schoolList;
            return View(chdList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}