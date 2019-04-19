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
        private string _PDFLocale= "./files/PDFCreator/minuta.pdf";

        public PdfCreatorController(IConverter converter)
        {
            _converter = converter;
        }
 
        [HttpGet("{contratcIds}/{request}")]
        public IActionResult CreatePDF(string contratcIds, string request)
        {
            try
            {
                GlobalSettings globalSettings = getGlobalConfig();

                ObjectSettings objectSettings = getObjectSettings();
                IContractRepository Repository = new ContractRepository();
                List<Contract> contratcs = Repository.GetByIdStringList(contratcIds);
                objectSettings.HtmlContent = TemplateGenerator.GetHTMLString(contratcs, request);

                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };

                _converter.Convert(pdf);
                var buffer = System.IO.File.ReadAllBytes(this._PDFLocale);
                string pdfString = Convert.ToBase64String(buffer);
                return File(buffer, "application/pdf");
            }
            catch (System.Exception)
            {
                
                throw;
            }          
        }

        private static ObjectSettings getObjectSettings()
        {
            return new ObjectSettings
            {
                PagesCount = true,
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };
        }

        private GlobalSettings getGlobalConfig()
        {
            return new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = _PDFLocale
            };
        }

    }

    class PdfRetorno{
        public string url { get; set; }
    }
}
