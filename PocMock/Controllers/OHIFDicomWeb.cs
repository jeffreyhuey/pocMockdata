using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text;


namespace PocMock.Controllers
{
    
    [ApiController]
    public class OHIFDicomWeb : ControllerBase
    {
        [Route("Dicomweb/studies")]
        [HttpGet]
        public ContentResult GetStudies([FromQuery]string studyInstanceUID)
        {
            if (string.IsNullOrEmpty(studyInstanceUID) == true)
            {
                //return list of matching studies
                //
                string FilePath = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory), @"studiesMockResponse.txt");

                string FileText = System.IO.File.ReadAllText(FilePath);

                return Content(FileText, "application/json");
            }
            else
            {
                //return one study for UID
                //
                string FilePath = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory), @"studyMockResponse.txt");

                string FileText = System.IO.File.ReadAllText(FilePath);

                return Content(FileText, "application/json");

            }

        }

        [Route("Dicomweb/studies/{studyUID}/series")]
        [HttpGet]
        public ContentResult getSeriesInfo(string studyUID, [FromQuery]string includefield)
        {
            string FilePath = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory), @"seriesMockResponse.txt");

            string FileText = System.IO.File.ReadAllText(FilePath);

            return Content(FileText, "application/json");
        }


        [Route("Dicomweb/studies/{studyUID}/series/{seriesUID}/metadata")]
        [HttpGet]
        public ContentResult getSeriesMetaData(string studyUID, string seriesUID)
        {
            string mockfile = "";
            if (seriesUID == "1.3.6.1.4.1.25403.345050719074.3824.20170125095438.6")
                mockfile = "seriesMetadata1.txt";
            else if (seriesUID == "1.3.6.1.4.1.25403.345050719074.3824.20170125095438.11")
                mockfile = "seriesMetadata2.txt";
            else if (seriesUID == "1.3.6.1.4.1.25403.345050719074.3824.20170125095449.8")
                mockfile = "seriesMetadata3.txt";
            else if (seriesUID == "1.3.6.1.4.1.25403.345050719074.3824.20170125095501.12")
                mockfile = "seriesMetadata4.txt";
            else if (seriesUID == "1.3.6.1.4.1.25403.345050719074.3824.20170125095506.10")
                mockfile = "seriesMetadata5.txt";
 
            

            string FilePath = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory), mockfile);

            string FileText = System.IO.File.ReadAllText(FilePath);

            return Content(FileText, "application/json");
        }


        [Route("Dicomweb/studies/{studyUID}/series/{seriesUID}/instances/{instanceUID}/frames/{frameNumber?}")]
        [HttpGet]
        public ActionResult getSeriesMetaData(string studyUID, string seriesUID, string instanceUID, int? frameNumber)
        {
            string mockfile = "";
            if (instanceUID == "1.3.6.1.4.1.25403.345050719074.3824.20170125095438.7" && frameNumber == 1)
                mockfile = "instance1Frame1.jpg";
            else if (instanceUID == "1.3.6.1.4.1.25403.345050719074.3824.20170125095446.1" && frameNumber == 1)
                mockfile = "instance2Frame1.jpg";
            else if (instanceUID == "1.3.6.1.4.1.25403.345050719074.3824.20170125095453.4" && frameNumber == 1)
                mockfile = "instance3Frame1.jpg";
            else if (instanceUID == "11.3.6.1.4.1.25403.345050719074.3824.20170125095503.1" && frameNumber == 1)
                mockfile = "instance4Frame1.jpg";
            else if (instanceUID == "1.3.6.1.4.1.25403.345050719074.3824.20170125095511.7" && frameNumber == 1)
                mockfile = "instance5Frame1.jpg";
            else if (instanceUID == "1.3.6.1.4.1.25403.345050719074.3824.20170125095438.10" && frameNumber == 1)
                mockfile = "instance6Frame1.jpg";
            else
                mockfile = "random.jpg";



            string FilePath = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory), mockfile);

            var image = System.IO.File.OpenRead(FilePath);

            return File(image, "image/jpg;transfer-syntax=1.2.840.10008.1.2.4.50"); //png instead of jls, transfer syntax 50 instead of 80
        }

    }
}
