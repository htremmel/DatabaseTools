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
        string Name { get; set; }
        string Server { get; set; }
        ITable<T> GetTable<T>() where T : class;
        List<object> GetTables();        
    }    
}
