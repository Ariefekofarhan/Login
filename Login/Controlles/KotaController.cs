using Login.Context;
using Login.Models;
using Login.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Controlles
{
    public class KotaController : Controller
    {
        KotaRepository KotaRepository;
        public KotaController(KotaRepository KotaRepository)
        {
            this.KotaRepository = KotaRepository;
        }

        //GetAll
        //GET
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Role").Equals("Admin"))
            {
                var data = KotaRepository.Get();
                return View(data);
            }
            return RedirectToAction("Unauthorized", "ErrorPage");
            
        }
        //GET BY ID
        //GET
        public IActionResult Detail(int id)
        {
            var data = KotaRepository.Get(id);
            return View(data);
        }

        //CREATE
        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Kota kota)
        {
            if (ModelState.IsValid)
            {
                var result = KotaRepository.Post(kota);
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }
        //UPDATE
        //GET
        public IActionResult Edit(int id)
        {
            //var data = myContext.Perkotaan.Find(id);
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Kota kota)
        {
            if (ModelState.IsValid)
            {
                
                var result = KotaRepository.Put(id, kota);
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }

        //DELETE
        //GET
        public IActionResult Delete(int id)
        {
            //var data = myContext.Perkotaan.Find(id);
            return View();
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Kota kota)
        {
            var result = KotaRepository.Delete(kota);
                if (result > 0)
                    return RedirectToAction("Index");
            return View();
        }
    }
}
