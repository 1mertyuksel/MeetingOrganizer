using DataAccessLayer_DAL_.EntityLayer.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DAL_.EntityLayer.Models.Concrete
{
    public class Meeting : BaseEntity
    {
        public string Topic { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List<Participant>? Participants { get; set; } = new List<Participant>(); // Nullable
    }
}
