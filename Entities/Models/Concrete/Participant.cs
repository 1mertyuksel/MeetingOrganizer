using DataAccessLayer_DAL_.EntityLayer.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DAL_.EntityLayer.Models.Concrete
{
    public class Participant : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Meeting>  Meetings { get; set; } = new List<Meeting>();
    }
}

