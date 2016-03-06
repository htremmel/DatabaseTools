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
	public partial class ExcelDatabase: DbConnection,IDataContext
    {

        #region Inhertied members
        public ITable<T> GetTable<T>() where T : class
        {
            throw new System.NotImplementedException();
        }

        protected override DbTransaction BeginDbTransaction(System.Data.IsolationLevel isolationLevel)
        {
            throw new System.NotImplementedException();
        }

        public override void ChangeDatabase(string databaseName)
        {
            throw new System.NotImplementedException();
        }

        public override void Close()
        {
            throw new System.NotImplementedException();
        }

        public override string ConnectionString
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

        protected override DbCommand CreateDbCommand()
        {
            throw new System.NotImplementedException();
        }

        public override string DataSource
        {
            get { throw new System.NotImplementedException(); }
        }

        public override string Database
        {
            get { throw new System.NotImplementedException(); }
        }

        public override void Open()
        {
            throw new System.NotImplementedException();
        }

        public override string ServerVersion
        {
            get { throw new System.NotImplementedException(); }
        }

        public override System.Data.ConnectionState State
        {
            get { throw new System.NotImplementedException(); }
        }

        #endregion
        
    }
}