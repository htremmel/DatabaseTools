using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.Common;

namespace DatabaseTools.Access
{
    public class AccessConnectionStringBuilder : ConnectionStringBuilder
    {
        private Drivers Driver { get; set; }
        private string Security
        {
            get
            {
                if (this.UserId == null) this.UserId = "admin";	
                if (this.Password == null) this.Password = "";
                if (this.Driver != Drivers.Odbc) return string.Format("User Id={0}; Password={1};",this.UserId, this.Password);
                return string.Format("Uid={0}; Pwd={1};", this.UserId, this.Password);
            }
        }

        private string DataSource
        {
            get
            {
                if (this.Driver != Drivers.Odbc) return string.Format("Data Source={0};", this.File.FullName);
                return string.Format("Dbq={0};", this.File.FullName);
            }
        }
        private string Provider 
        {
            get
            {
                return Providers[this.Driver];
            }
        }
        public string UserId { get; set; }
        public string Password { get; set; }
        public FileInfo File { get; set; }
		public override DbConnection DatabaseConnection {
			get 
			{
                DbConnection db = this.DataConnections[this.Driver];
                db.ConnectionString = this.ConnectionString;
                return db;
			}
		}
        public override string ConnectionString
        {
            get
            {
                if (this.Driver == Drivers.ACE) 
                    return string.Format("{0} {1} Persist Security Info=False;", this.Provider, this.DataSource);
                if(this.Driver == Drivers.Jet) return string.Format("{0} {1} {2}",this.Provider,this.DataSource,this.Security);
                return string.Format("{0} {1} {2}",this.Provider,this.DataSource,this.Security);
            }
        }

        public static event ErrorEventHandler NotValidFileType;
        public event ErrorEventHandler DatabaseConnectionError;

#region Dictionaries
        private static Dictionary<Drivers, string> Providers = new Dictionary<Drivers, string>()
        {
            { Drivers.ACE, "Provider=Microsoft.ACE.OLEDB.12.0;" },
            { Drivers.Jet, "Provider=Microsoft.Jet.OLEDB.4.0;" },
            { Drivers.Odbc, "Driver={Microsoft Access Driver (*.mdb, *.accdb)};"}
        };

        private Dictionary<Drivers, DbConnection> DataConnections = new Dictionary<Drivers,DbConnection>()
        {
            { Drivers.ACE, new System.Data.OleDb.OleDbConnection()},
            { Drivers.Jet, new System.Data.OleDb.OleDbConnection()},
            { Drivers.Odbc, new System.Data.Odbc.OdbcConnection()}
        };
        
        private static Dictionary<string, eFileType> FileTypes = new Dictionary<string, eFileType>()
        {
            {".mdb", eFileType.mbd},
            {".accbd", eFileType.accb }
        };

        private Dictionary<Drivers, string> DriverElaboration = new Dictionary<Drivers, string>()
        {
            { Drivers.ACE, "ACE Driver" },
            { Drivers.Jet, "Jet Driver" },
            { Drivers.Odbc, "ODBC Driver" }
        };
        
        public enum Drivers
        {
            ACE, Jet, Odbc
        }

        private enum eFileType
        {
            mbd, accb
        }
  
#endregion                

#region Constructors
        private AccessConnectionStringBuilder(): base()
        {

        }

        public AccessConnectionStringBuilder(string fileName, Drivers driver) : base()
        {
            this.File = new FileInfo(fileName);
            Driver = driver;
        }

        public AccessConnectionStringBuilder(FileInfo file, Drivers driver) : base()
        {
            this.File = file;
            Driver = driver;
        } 
#endregion
       
#region Static methods
        public static AccessConnectionStringBuilder AccessOleDb(string fileName)
        {
            return new AccessConnectionStringBuilder(fileName,WhichOledbProvider(fileName));
        }
#endregion

        private static bool TryGetFileType(string fileName, out eFileType fileType)
        {
            if (FileTypes.TryGetValue(Path.GetExtension(fileName), out fileType) == true) return true;
            NotValidFileType.Invoke(null, new ErrorEventArgs(new NotSupportedException()));
            return false;
        }

        public override string ToString()
        {
            return string.Format("Driver= {0} FileName= {1}", DriverElaboration[this.Driver], this.File.Name);
        }

        private static Drivers WhichOledbProvider(string fileName)
        {
            eFileType ft;
            if (TryGetFileType(fileName, out ft))
            {
                if (ft == eFileType.mbd) return Drivers.Jet;
                if (ft == eFileType.accb) return Drivers.ACE;
            }
            throw new FileNotFoundException();
        }
    }
}
