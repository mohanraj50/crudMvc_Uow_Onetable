using Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudMvc_Uow_Onetable_1.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            ServiceCRUD obj = new ServiceCRUD();
           var details =  obj.GetAllEmp();
            return View(details);
        }

        [HttpPost]
        public ActionResult Create(ModelEmp Obj)
        {
            ServiceCRUD obj = new ServiceCRUD();
            var details = obj.CreateEmp(Obj);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int empid)
        {
            ServiceCRUD obj = new ServiceCRUD();
            var details=   obj.GetEmpEditDetailById(empid);
            return View(details);
        }
        [HttpPost]
        public ActionResult Edit(ModelEmp Obj)
        {
            ServiceCRUD obj = new ServiceCRUD();
            var details = obj.EmpDetailUpdate(Obj);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int empid)
        {

            ServiceCRUD obj = new ServiceCRUD();
            var details= obj.GetEmpEditDetailById(empid);
            return View(details);

        }

        public ActionResult Delete(int Empid)
        {
            ServiceCRUD obj = new ServiceCRUD();
            var details= obj.GetEmpDeleteDetailById(Empid);
            return View(details);

        }

        [HttpPost]
        public ActionResult Delete(ModelEmp Obj)
        {
            ServiceCRUD obj = new ServiceCRUD();
            var detial=obj.EmpDetailDelete(Obj);
            return RedirectToAction("Index");

        }
    }
}

