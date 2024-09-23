using BusinessLogic_BL_.Abstract;
using DataAccessLayer_DAL_.Concrete;
using DataAccessLayer_DAL_.EntityLayer.DbContexts;
using DataAccessLayer_DAL_.EntityLayer.Models.Abstract;
using DataAccessLayer_DAL_.EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_BL_.Concrete
{
    public class MeetingService<T> : Service<T>, IMeetingService<T>
        where T : Meeting, new()
    {
        public MeetingService(AppDbContexts context) : base(context) // AppDbContexts kullanarak context'i belirtiyoruz
        {
        }
    }
}