using firstProjectmvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;


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
            TempData["SuccessMessage"] = "Save successfully!";
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
            TempData["SuccessMessage"] = "Updated successfully!";
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
           objuser.Name = dt.Rows[0]["Name"].ToString();
           objuser.Email = dt.Rows[0]["Email"].ToString();
           objuser.PhoneNumber = dt.Rows[0]["PhoneNumber"].ToString();
           objuser.Address = dt.Rows[0]["Address"].ToString();
            //objuser.CountryId = Convert.ToInt32(dt.Rows[0]["CountryId"].ToString());
            //objuser.StateId = Convert.ToInt32(dt.Rows[0]["StateId"].ToString());
            //objuser.CityId = Convert.ToInt32(dt.Rows[0]["CityId"].ToString());
            objuser.Gender = dt.Rows[0]["Gender"].ToString();
            return View(objuser);
        }

        //list

        [HttpGet]
        public ActionResult List()
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
                //objuser.CountryId = Convert.ToInt32(dt.Rows[i]["CountryId"].ToString());
                //objuser.StateId = Convert.ToInt32(dt.Rows[i]["StateId"].ToString());
                //objuser.CityId = Convert.ToInt32(dt.Rows[i]["CityId"].ToString());
                objuser.Name = dt.Rows[i]["Name"].ToString();
                objuser.Email = dt.Rows[i]["Email"].ToString();
                objuser.PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString();
                objuser.Address = dt.Rows[i]["Address"].ToString();
                objuser.Gender = dt.Rows[i]["Gender"].ToString();
                list.Add(objuser);
            }
            obj.MyUsers = list;
            return View(obj);
        }

        public ActionResult Details(int id)
        {

            User objdetails = new User();
            objdetails.UserId = id;
            BALUser user = new BALUser();
            DataTable dt = new DataTable();
            dt = user.FetchUserDetails(objdetails);


            List<User> list = new List<User>();
            User objuser = new User();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                objuser.UserId = Convert.ToInt32(dt.Rows[i]["UserId"].ToString());
                objuser.Name = dt.Rows[i]["Name"].ToString();
                objuser.Email = dt.Rows[i]["Email"].ToString();
                objuser.Gender = dt.Rows[0]["Gender"].ToString();
                objuser.PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString();

                //objuser.CountryId = Convert.ToInt32(dt.Rows[0]["CountryId"].ToString());
                //objuser.StateId = Convert.ToInt32(dt.Rows[0]["StateId"].ToString());
                //objuser.CityId = Convert.ToInt32(dt.Rows[0]["CityId"].ToString());

                //objuser.CountryName = dt.Rows[0]["CountryName"].ToString();
                //objuser.StateName = dt.Rows[0]["StateName"].ToString();
                //objuser.CityName = dt.Rows[0]["CityName"].ToString();

                //objuser.Address = dt.Rows[i]["Address"].ToString();
                list.Add(objuser);
            }
            objdetails.MyUsers = list;
            return View(objuser);
        }


        // [HttpPost]
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
                objuser.Name = dt.Rows[i]["Name"].ToString();
                objuser.Email = dt.Rows[i]["Email"].ToString();
                objuser.PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString();
                objuser.Address = dt.Rows[i]["Address"].ToString();
                //objuser.CountryId = Convert.ToInt32(dt.Rows[i]["CountryId"].ToString());
                //objuser.StateId = Convert.ToInt32(dt.Rows[i]["StateId"].ToString());
                //objuser.CityId = Convert.ToInt32(dt.Rows[i]["CityId"].ToString());
                objuser.Gender = dt.Rows[i]["Gender"].ToString();
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
            TempData["SuccessMessage"] = "Deleted Successfully!";
            refresh();
            return View();

        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            User obj2 = new User();
            obj2.UserId = id;
            BALUser obj = new BALUser();
            DataTable dt = new DataTable();
            dt = obj.FetchUserDetails(obj2);

            User objuserdelete = new User();
            objuserdelete.UserId = Convert.ToInt32(dt.Rows[0]["UserId"].ToString());
            objuserdelete.Name = dt.Rows[0]["Name"].ToString();
            objuserdelete.Email = dt.Rows[0]["Email"].ToString();
            objuserdelete.PhoneNumber = dt.Rows[0]["PhoneNumber"].ToString();
            objuserdelete.Address = dt.Rows[0]["Address"].ToString();
            //objuserdelete.CountryId = Convert.ToInt32(dt.Rows[0]["CountryId"].ToString());
            //objuserdelete.StateId = Convert.ToInt32(dt.Rows[0]["StateId"].ToString());
            //objuserdelete.CityId = Convert.ToInt32(dt.Rows[0]["CityId"].ToString());
            objuserdelete.Gender = dt.Rows[0]["Gender"].ToString();

            return View(objuserdelete);
        }
    }

    }