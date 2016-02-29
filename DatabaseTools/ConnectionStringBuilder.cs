using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTools
{
    public abstract class ConnectionStringBuilder
    {
        public virtual string ConnectionString { get; private set; }
        public ConnectionStringBuilder()
        {

        }

        public abstract void Build();
        public abstract bool TryConnection();
    }
}
