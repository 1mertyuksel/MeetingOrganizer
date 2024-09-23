using AutoMapper;
using BusinessLogic_BL_.Abstract;
using BusinessLogic_BL_.Concrete;
using DataAccessLayer_DAL_.EntityLayer.Models.Concrete;
using MeetingOrganizerWebAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto;

namespace MeetingOrganizerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly MeetingService<Meeting> _meetingService;
        private readonly IMapper _mapper;

        public MeetingsController(MeetingService<Meeting> meetingService, IMapper mapper)
        {
            _meetingService = meetingService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMeetings()
        {
            var meetings = await _meetingService.GetAllAsync();
            var meetingDtos = _mapper.Map<IEnumerable<MeetingDto>>(meetings);
            return Ok(meetingDtos);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeetingById(int id)
        {
            var meeting = await _meetingService.GetById(id); // FindAsync yerine GetById kullanıldı
            if (meeting == null)
                return NotFound();

            var meetingDto = _mapper.Map<MeetingDto>(meeting);
            return Ok(meetingDto); // meetingDto döndürülmeli
        }


        [HttpPost]
        public async Task<IActionResult> CreateMeeting([FromBody] MeetingDto meetingDto)
        {
            if (meetingDto == null)
                return BadRequest("Meeting data is null");

            var meeting = _mapper.Map<Meeting>(meetingDto);

            try
            {
                await _meetingService.AddAsync(meeting);
            }
            catch (Exception ex)
            {
                // Hata durumunda 500 hata kodu ve hata mesajı döndürülüyor  
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            var createdMeetingDto = _mapper.Map<MeetingDto>(meeting);
            return CreatedAtAction(nameof(GetMeetingById), new { id = meeting.Id }, createdMeetingDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeeting(int id)
        {
            var meeting = await _meetingService.GetById(id);
            if (meeting == null)
                return NotFound();

                await _meetingService.DeleteAsync(meeting);
         return NoContent(); // Başarılı bir silme işlemi için 204 No Content döndürülür
        }

    }
}
