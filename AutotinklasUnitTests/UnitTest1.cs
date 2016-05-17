using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using AutotinklasInformacinėSistema;
using AutotinklasInformacinėSistema.Controllers;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Diagnostics;
using System.Net;

namespace AutotinklasUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateActionTestValid()
        {
            var controller = new PadalinysController();
            AutotinklasInformacinėSistema.Padalinys p = new AutotinklasInformacinėSistema.Padalinys();
            p.miestas = "Testonija";
            p.adresas = "Testerijos pr. 404";
            ActionResult result = controller.Create(p);
            NUnit.Framework.Assert.That(result, Is.InstanceOf<RedirectToRouteResult>());
            RedirectToRouteResult routeResult = result as RedirectToRouteResult;
            NUnit.Framework.Assert.AreEqual(routeResult.RouteValues["action"], "Index");
        }
        [TestMethod]
        public void CreateActionTestInvalid()
        {
            var controller = new PadalinysController();
            AutotinklasInformacinėSistema.Padalinys p = new AutotinklasInformacinėSistema.Padalinys();
            controller.ViewData.ModelState.AddModelError("Key", "ErrorMessage");
            ActionResult result = controller.Create(p);
            NUnit.Framework.Assert.That(result, Is.InstanceOf<ViewResult>());
            ViewResult viewResult = result as ViewResult;
            NUnit.Framework.Assert.AreEqual(viewResult.ViewName, "");
        }
        public static double TimeMethod(Action<string> methodToTime, string url)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            methodToTime(url);
            stopwatch.Stop();
            return ((double)stopwatch.ElapsedMilliseconds / 1000.0);
        }
        public static void doRequest(string url)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            var resp = request.GetResponse();

        }

        [TestMethod]
        public void CreateActionTestTime()
        {
            string url = String.Format("http://localhost:60137/Padalinys/Create");
            double time = TimeMethod(doRequest, url);

            NUnit.Framework.Assert.AreEqual(true, time < 3);
        }
    }
}
