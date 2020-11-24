using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongKiemSoatRaVao.Controllers
{
    public class CameraController : Controller
    {
        public IActionResult Index()
        {
            string adr = "rtsp://admin:admin@10.0.4.201:554/cam/realmonitor?channel=1&subtype=00&authbasic=YWRtaW46YWRtaW4=";
            
            return View();
        }


    }
}
