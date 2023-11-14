using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;

namespace Logic
{
    public class PresentationLog
    {
        PresentationDat objPre = new PresentationDat();

        public DataSet showPresentation()
        {
            return objPre.showPresentation();
        }
        public bool savePresentation(string _tipo, int _cantidad, decimal _preciounidad)
        {
            return objPre.savePresentation(_tipo, _cantidad, _preciounidad);
        }
        public bool updatePresentation(int _id, string _tipo, int _cantidad, decimal _preciounidad)
        {
            return objPre.updatePresentation(_id, _tipo, _cantidad, _preciounidad);
        }
        public bool deletePresentation(int _pre_id)
        {
            return objPre.deletePresentation(_pre_id);
        }

        public DataSet showPresentationDDL()
        {            
            return objPre.showPresentationDDL();
        }
    }
}