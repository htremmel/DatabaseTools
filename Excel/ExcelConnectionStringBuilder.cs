/*
 * Created by SharpDevelop.
 * User: HTREMMEL
 * Date: 3/3/2016
 * Time: 8:19 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;

namespace DatabaseTools.Excel
{
	public class ExcelConnectionStringBuilder: ConnectionStringBuilder
	{
		private bool isHdr = false;
		private bool isDataAsText = true;
		private eFileType _fileType;
		private Driver _driver;
		private string _provider;

        #region Properties
        public string DriverName
        {
            get { return this.DriverNames[_driver]; }
        }
        public string FileTypeName
        {
            get { return this.FileTypeNames[_fileType]; }
        }
        public FileInfo File { get; set; }
        public bool IncludeColumnNames
        {
            get { return isHdr; }
            set { isHdr = value; }
        }
        public bool? TreatDataAsText { get; set; }
        public override System.Data.Common.DbConnection DatabaseConnection
        {
            get
            {
                return GetConnection();
            }
        }
        public override string ConnectionString
        {
            get
            {
                return Build();
            }
        }
        #endregion    
    
        public event ErrorEventHandler OnError;
		
		#region Dictionaries
		public enum eFileType
		{
			xlsb, xlsm, xlsx, xls
		}
		
		public enum Driver
		{
			Ace, Jet, Odbc, xlReader, AdoNet
		}
		
		private Dictionary<eFileType,string> FileTypeNames = new Dictionary<eFileType, string>()
		{
			{eFileType.xlsb, "Excel +2007 Office Open Xml" },
			{eFileType.xlsm, "Excel +2007 Macro-enabled" },
			{eFileType.xlsx, "Excel +2007" },
			{eFileType.xls, "Excel 1997 to 2003"}					
		};

        private Dictionary<string, eFileType> FileTypeExtensions = new Dictionary<string, eFileType>()
        {
            {".xlsb", eFileType.xlsb},
            {".xlsm", eFileType.xlsm},
            {".xlsx", eFileType.xlsx},
            {".xls", eFileType.xls}
        };
		
		private Dictionary<Driver,string> DriverNames = new Dictionary<Driver, string>()
		{
			{Driver.Ace, "Microsoft ACE OLEDB 12.0"},
			{Driver.Jet, "Microsoft Jet OLE DB 4.0"},
			{Driver.Odbc, "Microsoft Excel 2007 ODBC Driver"},
			{Driver.xlReader, ".NET xlReader for Microsoft Excel"},
			{Driver.AdoNet, "RSSBus ADO.NET Provider for Excel"}			
		};

        private Dictionary<Driver, DbConnection> DriverConnections = new Dictionary<Driver, DbConnection>()
        {
            {Driver.Ace, new OleDbConnection()},
            {Driver.Jet, new OleDbConnection()},
            {Driver.Odbc, new OdbcConnection()},
            {Driver.AdoNet, null},
            {Driver.xlReader, null}
        };
		#endregion
		
		#region Constructors
		public ExcelConnectionStringBuilder(Driver driver, FileInfo file)
		{
			this._driver = driver;
            this.File = file;
            this._fileType = GetFileType();
		}

        public static ExcelConnectionStringBuilder ExcelOleDb(FileInfo file)
        {
            return new ExcelConnectionStringBuilder(Driver.Ace, file);
        }
		#endregion

        #region Overriden members
        //public override bool TryConnection()
        //{
        //    using (OleDbConnection conn = new OleDbConnection(this.ConnectionString))
        //    {
        //        conn.Open();
        //        if (conn.State != ConnectionState.Open)
        //        {
        //            return false;
        //        }
        //        return true;
        //    }
        //}
        #endregion

        #region Helpers
        private string Build()
		{
            if (this._driver == Driver.Odbc) return "Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};DBQ=" + this.File.FullName+";";
            switch (this._fileType)
            {
                case eFileType.xlsb:
                    return string.Format("Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties='Excel 12.0; {1} {2}'", this.File.FullName, this.IsHdrToString(), this.DataAsTextToString());
                case eFileType.xlsm:
                    return string.Format("Provider=Microsoft.ACE.OLEDB.12.0 Macro; Data Source={0}; Extended Properties='Excel 12.0 Xml; {1} {2}'", this.File.FullName, this.IsHdrToString(), this.DataAsTextToString());
                case eFileType.xlsx:
                    return string.Format("Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties=\"Excel 12.0 Xml; {1} {2}\"", this.File.FullName, this.IsHdrToString(), this.DataAsTextToString());
                case eFileType.xls:
                    if (this._driver == Driver.Ace) return string.Format("Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties='Excel 8.0; {1} {2}'", this.File.FullName, this.IsHdrToString(), this.DataAsTextToString());
                    return string.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; Extended Properties=\"Excel 12.0 Xml; {1} {2}\"", this.File.FullName, this.IsHdrToString(), this.DataAsTextToString());
                default:
                    goto case eFileType.xlsb;
            }
		}
		
		private DbConnection GetConnection()
		{
            DbConnection db = this.DriverConnections[this._driver];
            db.ConnectionString = this.ConnectionString;
            return db;
		}

        private eFileType GetFileType()
        {
            try
            {
                eFileType o;
                if (this.FileTypeExtensions.TryGetValue(Path.GetExtension(this.File.FullName), out o))
                {
                    return o;
                }
                throw new FileLoadException("File type is not supported.");
            }
            catch (FileLoadException ex)
            {
                OnError.Invoke(this, new ErrorEventArgs(new FileLoadException("File type is not supported.")));
                throw ex;
            }
            catch (System.Exception ex)
            {
                OnError.Invoke(this, new ErrorEventArgs(ex));
                throw ex;
            }
        }
		
		private string IsHdrToString()
		{
			if (this.isHdr) return "HDR=YES;";
			return "HDR=NO;";
		}
		
		private string DataAsTextToString()
		{
            if (this.TreatDataAsText == null) return "";
			if (this.TreatDataAsText == true) return "IMEX=1;";
            return "IMEX=0;";
		}
		#endregion
		
	}
}