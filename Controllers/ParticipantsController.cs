using AutoMapper;
using BusinessLogic_BL_.Concrete;
using DataAccessLayer_DAL_.EntityLayer.Models.Concrete;
using MeetingOrganizerWebAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingOrganizerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly ParticipantService<Participant> _participantService;
        private readonly IMapper _mapper;

        public ParticipantsController(ParticipantService<Participant> participantService , IMapper mapper)
        {
            _participantService = participantService;
            _mapper = mapper;
        }

        [HttpGet]   
        public async Task<IActionResult> GetAllParticipants()
        {
            var participants = await _participantService.GetAllAsync();
            var participantsDtos = _mapper.Map<IEnumerable<ParticipantDto>>(participants);
            return Ok(participantsDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipantById(int id)
        {
            var participant = await _participantService.GetById(id); // FindAsync yerine GetById kullanıldı
            if (participant == null)
                return NotFound();

            var participantDto = _mapper.Map<ParticipantDto>(participant);
            return Ok(participantDto); // participantDto döndürülmeli
        }



        [HttpPost]
        public async Task<IActionResult> CreateParticipant([FromBody] ParticipantDto participantDto)
        {
            if (participantDto == null)
                return BadRequest();

            var participant = _mapper.Map<Participant>(participantDto);
            await _participantService.AddAsync(participant);
            return CreatedAtAction(nameof(GetParticipantById), new { id = participant.Id }, participant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParticipant(int id, [FromBody] ParticipantDto participantDto)
        {
            if (id != participantDto.Id)
                return BadRequest();

            var participant = await _participantService.GetById(id);
            if (participant == null)
                return NotFound();

            
            var updatedParticipant = _mapper.Map<Participant>(participantDto);

            await _participantService.UpdateAsync(updatedParticipant);
            return NoContent(); 
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant(int id)
        {
            var participant = await _participantService.GetById(id);
            if (participant == null)
                return NotFound();

            await _participantService.DeleteAsync(participant);
            return NoContent();
        }





    }
}
