using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DatabaseTools_Tests
{
    class DirectoryHelper
    {
        FileInfo _fi;
        List<string> _paths;
        int _lim = 5; //Limits the number of saves to keep it light weight

        #region Properties
        public List<string> SavedPaths
        {
            get
            {
                return _paths;
            }
        }

        public int PathLimit
        {
            set
            {
                _lim = value;
            }
            get
            {
                return _lim;
            }
        }   
        #endregion        

        #region Constructors
        public DirectoryHelper(FileInfo fi)
        {
            
        }

        public DirectoryHelper(string path)
        {

        }
        #endregion
        

        public void ParentDirectory()
        {
                
        }

        public void RestorePrevious()
        {

        }
    }
}
