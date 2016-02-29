using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Linq;
using System.Data.Common;

namespace DatabaseTools
{
    public interface IDataContext : IDbConnection
    {        
        ITable<T> GetTable<T>() where T : class;
        
    }    
}
