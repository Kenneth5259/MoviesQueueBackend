using System.Collections.Generic;
using MovieQueueBackend.Models;
using MovieQueueBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieQueueBackend.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase {
        private readonly QueueService _queueService;

        public QueueController(QueueService queueService) {
            _queueService = queueService;
        }

        [HttpGet]
        public ActionResult<List<QueueItem>> Get() => _queueService.Get();

        [HttpPost]
        public IActionResult Create(QueueItem item) {
            if(item == null) {
                return NoContent();
            } else {
                _queueService.Create(item);
                return Ok();
            }
        }

    }
}