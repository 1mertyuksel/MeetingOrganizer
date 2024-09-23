using AutoMapper;
using DataAccessLayer_DAL_.EntityLayer.Models.Concrete;
using MeetingOrganizerWebAPI.DTOs;

namespace MeetingOrganizerWebAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Participant, ParticipantDto>().ReverseMap();
            CreateMap<Meeting, MeetingDto>().ReverseMap();

            
        }
    }
}
