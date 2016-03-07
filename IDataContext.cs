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
        List<ITable<T>> Tables { get; }

        ITable<object> ITable
        {
            get;
            set;
        }
     
        ITable<T> GetTable<T>() where T : class;
        
    }    
}
