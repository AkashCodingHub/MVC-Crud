using firstProjectmvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;


namespace firstProjectmvc.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Index()
        {
            return View();
        }

        //Save 

        [HttpPost]
        public ActionResult Create(User obj)
        {
            BALUser user = new BALUser();
            user.save(obj);
            refresh();
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //Update

        [HttpPost]
        public ActionResult Update(User obj)
        {
            BALUser userupdate = new BALUser();
            userupdate.UpdateUser(obj);
            refresh();
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            User obj1 = new User();
            obj1.UserId = id;
            BALUser obj = new BALUser();
            DataTable dt = new DataTable();
           dt= obj.FetchUserDetails(obj1);

           User objuser = new User();
           objuser.UserId = Convert.ToInt32(dt.Rows[0]["UserId"].ToString());
           objuser.FirstName = dt.Rows[0]["FirstName"].ToString();
           objuser.LasttName = dt.Rows[0]["LastName"].ToString();
           objuser.PhoneNumber = dt.Rows[0]["PhoneNumber"].ToString();
           objuser.Address = dt.Rows[0]["Address"].ToString();
      
          return View(objuser);
        }

        //list

        [HttpGet]
        public ActionResult Details()
        {
            BALUser user = new BALUser();
            DataTable dt = new DataTable();
            dt = user.Fetch();
            User obj = new User();

            List<User> list = new List<User>();
            for (int i = 0; i < dt.Rows.Count; i++) { 
            User objuser = new User();
            objuser.UserId = Convert.ToInt32(dt.Rows[i]["UserId"].ToString());
            objuser.FirstName = dt.Rows[i]["FirstName"].ToString();
            objuser.LasttName = dt.Rows[i]["LastName"].ToString();
            objuser.PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString();
            objuser.Address = dt.Rows[i]["Address"].ToString();
            list.Add(objuser);
            }
            obj.MyUsers =list;
            return View(obj);
        }
        public void refresh()
        {
            BALUser user = new BALUser();
            DataTable dt = new DataTable();
            dt = user.Fetch();
            User obj = new User();

            List<User> list = new List<User>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                User objuser = new User();
                objuser.UserId = Convert.ToInt32(dt.Rows[i]["UserId"].ToString());
                objuser.FirstName = dt.Rows[i]["FirstName"].ToString();
                objuser.LasttName = dt.Rows[i]["LastName"].ToString();
                objuser.PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString();
                objuser.Address = dt.Rows[i]["Address"].ToString();
                list.Add(objuser);
            }
            obj.MyUsers = list;
        }

        //Delete

        [HttpPost]
        public ActionResult Delete(User obj)
        {
            BALUser userdelete = new BALUser();
            userdelete.DeleteUser(obj);
            refresh();
            return View();

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            User objdelete = new User();
            objdelete.UserId = id;
            BALUser obj = new BALUser();
            DataTable dt = new DataTable();
            dt = obj.FetchUserDetails(objdelete);

            User objuserdelete = new User();
            objuserdelete.UserId = Convert.ToInt32(dt.Rows[0]["UserId"].ToString());
            objuserdelete.FirstName = dt.Rows[0]["FirstName"].ToString();
            objuserdelete.LasttName = dt.Rows[0]["LastName"].ToString();
            objuserdelete.PhoneNumber = dt.Rows[0]["PhoneNumber"].ToString();
            objuserdelete.Address = dt.Rows[0]["Address"].ToString();

            return View(objuserdelete);
        }
    }

}