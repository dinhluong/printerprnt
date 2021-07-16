using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarMicronics.CloudPrnt;
using StarMicronics.CloudPrnt.CpMessage;
using System.Text.Json.Serialization;

namespace PrinterPRNTController.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrinterPRNTController : ControllerBase
    {
        private readonly ILogger<PrinterPRNTController> _logger;

        public PrinterPRNTController(ILogger<PrinterPRNTController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string HandleCloudPRNTPoll(string request)
        {
            PollRequest pollRequest = PollRequest.FromJson(request);
            Console.WriteLine(
                String.Format("Received CloudPRNT request from {0}, status: {1}",
                pollRequest.printerMAC,
                pollRequest.statusCode
            ));
            if(pollRequest.DecodedStatus.CoverOpen){
                Console.WriteLine("Printer cover is open");
            }
	        
            // Create a response object
            PollResponse pollResponse = new PollResponse();

            // print image at this time
            pollResponse.jobReady = true;
            string[] availableOutputMediaTypes = Document.GetOutputTypesFromFileName("jobs/order.png");
            pollResponse.mediaTypes = availableOutputMediaTypes.ToList();

            return pollResponse.ToJson();
        }
        
    }
}
