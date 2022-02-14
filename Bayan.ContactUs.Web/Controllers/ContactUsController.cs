using Bayan.ContactUs.Core.Dto;
using Bayan.ContactUs.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bayan.ContactUs.Web.Controllers
{
    public class ContactUsController : Controller
    {
        // GET: ContactUs
        public readonly IContactUs _repo;

        public ContactUsController(IContactUs repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            
            return View();
        }

        // GET: All Data
        public ActionResult Admin(int id)
        {
            var data = _repo.GetAll();
            return View(data);
        }


        // POST: ContactUs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactUsDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  var res =  _repo.Add(dto);
                  return Ok(res);
                }
                else
                    return BadRequest();

            }
            catch
            {
                return View();
            }
        }

     
    }
}
