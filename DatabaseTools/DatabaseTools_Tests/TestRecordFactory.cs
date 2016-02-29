using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DatabaseTools_Tests
{
    internal class TestRecordFactory
    {
        DataTable _dt;
        int _recNum;
        private string[] _lapTopPaths = {@"D:\Dropbox\2-Projects\InvoiceTracker\0-Research\20150526_SGCSG_ESA_AvianSurvey_NTP.pdf",
                                        @"D:\Dropbox\2-Projects\InvoiceTracker\0-Research\20150527_SGCSG_ESA_AvianSurvey_Encumberance.pdf",
                                        @"D:\Dropbox\2-Projects\InvoiceTracker\0-Research\20151203_SGCSG_ESA_AvianSurvey_CAGN_117522.pdf"};

         
        public TestRecordFactory(int recsCnt, DataTable dt)
        {
            _dt = dt;
            _recNum = recsCnt;
        }

        public List<DataRow> CreateTestRecords()
        {
            List<DataRow> l = new List<DataRow>();
            for (int i = 0; i < _recNum; i++)
            {
                l.Add(CreateTestRecord());
            }
            return l;
        }

        public DataRow CreateTestRecord()
        {
            TestRecord r = new TestRecord(_lapTopPaths[0], _dt);
            r.User_First_Name = "Hans";
            r.User_Last_Name = "Tremmel";
            return r.ToDataRow();
        }
    }
}
