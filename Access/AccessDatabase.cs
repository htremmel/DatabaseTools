using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Common;
using System.Data;

namespace DatabaseTools.Access
{
    public class AccessDatabase : DbConnection, IDataContext
    {
        
        public AccessDatabase(string connectionString)
            : base()
        {
            this.ConnectionString = connectionString;
        }

        #region Static methods
        [STAThread]
        public static FileInfo AccessSaveAsDialog()
        {
            try
            {
                SaveFileDialog sv = new SaveFileDialog()
                {
                    RestoreDirectory = true,
                    Filter = "Access 2000-2003 (*.mdb)|*.mdb|Access 2007 (*.accdb)|*accdb",
                    Title = "Create New Access Database"
                };
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    return new FileInfo(sv.FileName);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [STAThread]
        public static FileInfo AccessOpenDialog()
        {
            try
            {
                OpenFileDialog di = new OpenFileDialog()
                {
                    RestoreDirectory = true,
                    Filter = "Access 2000-2003 (*.mdb)|*.mdb|Access 2007 (*.accdb)|*accdb",
                    Title = "Select an Access Database.",
                    CheckFileExists = true,
                    CheckPathExists = true
                };
                if (di.ShowDialog() == DialogResult.OK)
                {
                    return new FileInfo(di.FileName);
                }
                throw new Exception();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static AccessDatabase CreateFromFile()
        {
            return new AccessDatabase(AccessOpenDialog().FullName);
        }

        public static AccessDatabase CreateFromFile(string fileName)
        {
            throw new NotImplementedException();
        }

        #endregion        

        public ITable<T> GetTable<T>() where T : class
        {
            //TODO: How to get connectivity to the table?  A dicitionary that translates the POCO to the table. 
            throw new NotImplementedException();
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        public override void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override string ConnectionString
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        protected override DbCommand CreateDbCommand()
        {
            throw new NotImplementedException();
        }

        public override string DataSource
        {
            get { throw new NotImplementedException(); }
        }

        public override string Database
        {
            get { throw new NotImplementedException(); }
        }

        public override void Open()
        {
            OleDbConnection db = new OleDbConnection(this.ConnectionString);
            try
            {
                do
                {
                
                } while (true);
                if (db.State != ConnectionState.Open) 
            }
            
        }

        public override string ServerVersion
        {
            get { throw new NotImplementedException(); }
        }

        public override ConnectionState State
        {
            get { throw new NotImplementedException(); }
        }


        public event void ErrorMessage;
    }
        
}
