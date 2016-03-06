using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;

namespace DatabaseTools
{
    public abstract class ConnectionStringBuilder
    {
        public event StateChangeEventHandler OnTryConnection;

        public abstract string ConnectionString { get; }
        public abstract DbConnection DatabaseConnection { get; }
        public virtual DbConnectionStringBuilder CommonStringBuilder
        {
            get
            {
                return new DbConnectionStringBuilder() { ConnectionString = this.ConnectionString };
            }
        }

        public virtual bool TryConnection()
        {
            using (DbConnection db = this.DatabaseConnection)
            {
                do
	            {
	                db.Open();
                    if (db.State == ConnectionState.Open)
                    {
                        if(OnTryConnection != null) OnTryConnection.Invoke(this, new StateChangeEventArgs(ConnectionState.Closed,db.State));
                        return true;
                    }
	            } while (db.State == ConnectionState.Connecting);
                if (OnTryConnection != null) OnTryConnection.Invoke(this, new StateChangeEventArgs(ConnectionState.Closed, db.State));
                return false;
            }
        }
    }
}
