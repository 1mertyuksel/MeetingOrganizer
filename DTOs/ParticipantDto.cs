﻿namespace MeetingOrganizerWebAPI.DTOs
{
   
    public class ParticipantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int MeetingId { get; set; }
    }
}
