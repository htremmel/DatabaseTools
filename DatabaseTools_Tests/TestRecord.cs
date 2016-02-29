using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace DatabaseTools_Tests
{
    internal class TestRecord
    {
        DataTable _targ;
        FileInfo _fi;

        #region Properties
        private string _fname;

        public string User_First_Name
        {
            get { return _fname; }
            set { _fname = value; }
        }

        private string _lname;

        public string User_Last_Name
        {
            get { return _lname; }
            set { _lname = value; }
        }

        private double _rnd;

        public double Some_Rnd_Num
        {
            get { return _rnd; }
        }

        private FileStream _fs;

        public FileStream Sample_File_Binary
        {
            get { return _fs; }
            set { _fs = value; }
        }

        private string _filen;

        public string File_Name
        {
            get { return _filen; }
            set { _filen = value; }
        }

        public string TableName
        {
            get { return "Test"; }
        }

        public bool IsNewRecord
        {
            get { return true; }
        }

        #endregion

        #region Constructors
        public TestRecord(string filePath, DataTable target)
        {
            _fi = new FileInfo(filePath);
            _targ = target;
        }
        #endregion

        public DataRow ToDataRow()
        {
            Random ran = new Random();
            DataRow r = _targ.NewRow();
            r["User_First_Name"] = _fname;
            r["User_Last_Name"] = _lname;
            r["Access_Time"] = System.DateTime.Now;
            r["Some_Rnd_Num"] = ran.Next(1);
            r["Sample_File_Binary"] = null;
            r["file_Name"] = _fi.Name;
            return r;
        }
    }
}
