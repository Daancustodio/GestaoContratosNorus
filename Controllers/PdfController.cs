using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using GestaoContratosNorus.Domain;
using GestaoContratosNorus.Repository;
using GestaoContratosNorus.Utility;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestaoContratosNorus.Controllers
{
    [Route("api/pdf")]
    [ApiController]
    [EnableCors("MyPolicy")]    
    public class PdfCreatorController : ControllerBase
    {
        private IConverter _converter;
 
        public PdfCreatorController(IConverter converter)
        {
            _converter = converter;
        }
 
        [HttpPost]
        public IActionResult CreatePDF([FromBody] List<Contract> contratcs)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = @".\files\PDFCreator\minuta.pdf"
            };
 
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(contratcs),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet =  Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };
 
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
 
            var file = _converter.Convert(pdf);
            return Ok("http://loscalhost:5000/files/PDFCreator/minuta.pdf");
        }
    }
}
