/*
 * Created by SharpDevelop.
 * User: HTREMMEL
 * Date: 3/3/2016
 * Time: 7:56 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Data.Common;

namespace DatabaseTools.Excel
{
	public partial class ExcelDatabase: IDataContext
    {

        #region Inhertied members
        

        #endregion

        public ITable<T> GetTable<T>() where T : class
        {
            throw new System.NotImplementedException();
        }

        public System.Data.IDbTransaction BeginTransaction(System.Data.IsolationLevel il)
        {
            throw new System.NotImplementedException();
        }

        public System.Data.IDbTransaction BeginTransaction()
        {
            throw new System.NotImplementedException();
        }

        public void ChangeDatabase(string databaseName)
        {
            throw new System.NotImplementedException();
        }

        public void Close()
        {
            throw new System.NotImplementedException();
        }

        public string ConnectionString
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public int ConnectionTimeout
        {
            get { throw new System.NotImplementedException(); }
        }

        public System.Data.IDbCommand CreateCommand()
        {
            throw new System.NotImplementedException();
        }

        public string Database
        {
            get { throw new System.NotImplementedException(); }
        }

        public void Open()
        {
            throw new System.NotImplementedException();
        }

        public System.Data.ConnectionState State
        {
            get { throw new System.NotImplementedException(); }
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public string Name
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public string Server
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public System.Collections.Generic.List<object> GetTables()
        {
            throw new System.NotImplementedException();
        }
    }
}