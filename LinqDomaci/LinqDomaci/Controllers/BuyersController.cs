using LinqDomaci.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace LinqDomaci.Controllers
{
    public class BuyersController : Controller
    {
        // GET: Buyers
        public ActionResult Index()
        {
            return View();
        }

        public List<Kupac> Details()
        {
            List <Kupac> kupci = new List<Kupac>()
            {
                new Kupac{Id =1, Name = "Marko", Age= 45, City = "Novi Sad"},
                new Kupac{Id =2, Name = "David", Age= 17, City = "Beograd"},
                new Kupac{Id =3, Name = "Nikola", Age= 60, City = "Nis"},
                new Kupac{Id =4, Name = "Stefan", Age= 35, City = "Kragujevac"}
            };

            return kupci;
        }

        public ActionResult GetBuyer()
        {
            List<Kupac> kupci = Details();

            var kupac = from k in kupci where k.Id == 3 select k;

            return View();

           
        }


        public ActionResult GetYoungest()
        {
            List<Kupac> kupci = Details();
            var kupac = kupci.OrderBy(p => p.Age).First();

            return View();
        }

        public ActionResult GetLegalBuyers()
        {
            List<Kupac> kupci = Details();
            var kupac = kupci.Where(k => k.Age >= 18 && k.Age <= 50).ToList();
            return View();
        }

        public ActionResult SortBuyers()
        {
            List<Kupac> kupci = Details();

            var k = kupci.OrderByDescending(s => s.Age).ToList();

            return View();
        }

        public ActionResult BelgradeBuyers()
        {
            List<Kupac> kupci = Details();
            var kupac = kupci.Where(c => c.City == "Beograd");

            //var kupac = from k in kupci where k.City == "Beograd" select k;
            return View();

        }

        public ActionResult BuyerWithoutI()
        {
            List<Kupac> kupci = Details();
            var kupac = kupci.Where(k=>!k.Name.Contains('i'));

            return View();
        }
        public ActionResult SortByName()
        {
            List<Kupac> kupci = Details();

            var kupac = kupci.Where(k => k.Name.Contains('a')).OrderBy(k => k.Name);

            return View();
        }

        //zadatak2
        public ActionResult Sort()
        {
            var orderByResult = Details().OrderBy(s => s.Name).ThenBy(s => s.Age);
            List<Kupac> kupci = Details();
            var orderBy = from k in kupci.OrderBy(k => k.Age)
                          orderby k.Name
                          select k;

            return View(orderBy);       
                          
                         
        }

    }
}