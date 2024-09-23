namespace MeetingOrganizerWebAPI.DTOs
{
    public class MeetingDto
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List<ParticipantDto>? Participants { get; set; }
    }
}
