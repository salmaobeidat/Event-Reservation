using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReservation.core.Icommon
{
    public interface IDbContext
    {
        DbConnection Connection { get; }
    }
}
