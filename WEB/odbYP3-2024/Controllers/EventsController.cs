using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using odbYP3_2024.Data;
using System.Text;

namespace odbYP3_2024.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly OdbYp32024Context _context;

        public EventsController(OdbYp32024Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Получить список событий
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _context.Events
                .Select(e => new
                {
                    e.EventId,
                    e.Title,
                    e.DateTimeStart,
                    e.DateTimeEnd,
                    e.Description,
                    e.UserId,
                    Organizer = e.User.Name // Имя организатора
                })
                .ToListAsync();

            return Ok(events);
        }

        /// <summary>
        /// Скачивание события в .ics файл
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SwaggerOperation(Summary = "Скачивание события в формате .ics", Description = "Возвращает файл события для импорта в календарь")]
        [SwaggerResponse(200, "Успешно", typeof(FileContentResult))]
        [SwaggerResponse(404, "Событие не найдено")]
        [HttpGet("{id}/download")]
        public async Task<IActionResult> DownloadEvent([FromRoute] int id)
        {
            var eventData = await _context.Events
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.EventId == id);

            if (eventData == null)
                return NotFound();

            var icsContent = GenerateIcsContent(eventData);
            var fileName = $"{eventData.Title.Replace(" ", "_")}.ics";

            return File(Encoding.UTF8.GetBytes(icsContent), "text/calendar", fileName);
        }

        /// <summary>
        /// Генерация содержимого .ics файла
        /// </summary>
        /// <param name="eventData"></param>
        /// <returns></returns>
        private string GenerateIcsContent(Event eventData)
        {
            return $@"
                BEGIN:VCALENDAR
                VERSION:2.0
                BEGIN:VEVENT
                SUMMARY:{eventData.Title}
                DTSTART:{eventData.DateTimeStart:yyyyMMdd}
                DTEND:{eventData.DateTimeEnd:yyyyMMdd}
                DESCRIPTION:{eventData.Description}
                ORGANIZER:{eventData.User?.Name ?? "Unknown"}
                STATUS:CONFIRMED
                END:VEVENT
                END:VCALENDAR";
        }
    }
}
