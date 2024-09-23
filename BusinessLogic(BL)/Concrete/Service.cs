using BusinessLogic_BL_.Abstract;
using DataAccessLayer_DAL_.Concrete;
using DataAccessLayer_DAL_.EntityLayer.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_BL_.Concrete
{
    public class Service<T> : Repository<T>, IService<T>
        where T : BaseEntity, new()
    {
        public Service(DbContext context) : base(context)
        {
            
        }
    }
}
