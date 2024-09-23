using DataAccessLayer_DAL_.Abstract;
using DataAccessLayer_DAL_.EntityLayer.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_BL_.Abstract
{
    public interface IService<T> : IRepository<T> where T : BaseEntity, new()
    {
    }
}
