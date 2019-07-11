using Core.CommonRepository;
using Core.DataBaseContext;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.DateRepository
{
   public class DateRepository : Repository<Date>, IDateRepository
    {
        public DateRepository(LoodosDatabaseContext context) : base(context)
        {
        }
    }
}
