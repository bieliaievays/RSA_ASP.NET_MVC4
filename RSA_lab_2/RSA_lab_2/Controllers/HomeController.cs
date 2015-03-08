﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RSA_lab_2.Controllers
{
    public class HomeController : Controller
    {
        private BigInteger _message;
        public ActionResult Encrypt()
        {
            try
            {
                Helper h = new Helper();
                StringBuilder sb = new StringBuilder();
                Random rnd1 = new Random();
                int p = Helper.Primes[rnd1.Next(Helper.Primes.Count)];
                System.Threading.Thread.Sleep(200);
                ViewBag.P = p;
                Random rnd2 = new Random();
                int q = Helper.Primes[rnd2.Next(Helper.Primes.Count)];
                ViewBag.Q = q;
                int n = p * q;
                ViewBag.N = n;
                int fi = (p - 1) * (q - 1);
                ViewBag.Fi = fi;
                int e = Helper.Primes.OrderBy(x => Guid.NewGuid()).Where(y => y < fi).FirstOrDefault();
                ViewBag.E = e;
                BigInteger d = BigInteger.Pow(e, Helper.Totient(fi) - 1) % fi;
                ViewBag.D = d;
                BigInteger c = BigInteger.Pow(_message, e) % n;
                ViewBag.C = c;
                //int pow = (int)Helper.Totient(9167368) - 1;
                //int d = (int)Math.Pow(3, pow);
                //BigInteger res = BigInteger.ModPow(3, 9167368 - 2, 9167368);


                ////double d = (Math.Pow(e, -1)) % fi;
                //BigInteger dd = BigInteger.ModPow(1 / 3, 1, 9167368);
                //ViewBag.D = d;
                return PartialView();
                //http://stackoverflow.com/questions/14181494/1-biginteger-in-c-sharp
                //https://ru.wikipedia.org/wiki/RSA#.D0.92.D1.8B.D0.B1.D0.BE.D1.80_.D0.B7.D0.BD.D0.B0.D1.87.D0.B5.D0.BD.D0.B8.D1.8F_.D1.81.D0.B5.D0.BA.D1.80.D0.B5.D1.82.D0.BD.D0.BE.D0.B3.D0.BE_.D0.BF.D0.BE.D0.BA.D0.B0.D0.B7.D0.B0.D1.82.D0.B5.D0.BB.D1.8F
                //http://www.itorian.com/2013/02/jquery-ajax-get-and-post-calls-to.html
            }
            catch (Exception ex)
            {
                return PartialView();
                //return ex.Message + ex.StackTrace;
            }
        }

        [HttpPost]
        public void PostMessage(string message)
        {
            if (!String.IsNullOrEmpty(message) && !String.IsNullOrEmpty(message))
            {
                //TODO TryParse implement 
                _message = BigInteger.Parse(message);
            }
        }

        public ActionResult Index()
        {
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}