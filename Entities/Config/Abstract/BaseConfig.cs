using DataAccessLayer_DAL_.EntityLayer.Models.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Config.Abstract
{
     public abstract class BaseConfig<T> : IEntityTypeConfiguration<T>
       where T : BaseEntity
        {
            public virtual void Configure(EntityTypeBuilder<T> builder)
            {
                builder.HasKey(e => e.Id);

            }
        }
}
