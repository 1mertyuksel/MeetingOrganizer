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
    public class ParticipantService<T> : Service<T>, IParticipantService<T>
    where T : BaseEntity, new()
    {
        public ParticipantService(AppDbContexts context) : base(context) // DbContext yerine AppDbContexts kullanıyoruz
        {
        }
    }

}
