using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;

namespace Logic
{
    public class TherapeuticActionLog
    {
        TherapeuticActionDat objTherap = new TherapeuticActionDat();

        public DataSet showTherapeuticAction()
        {
            return objTherap.showTherapeuticAction();
        }

        public bool saveTherapeuticAction(String p_acte_name, String p_acte_description)
        {
            return objTherap.saveTherapeuticAction(p_acte_name, p_acte_description);
        }


        public bool updateTherapeuticAction(int p_acte_id, string p_acte_name, string p_acte_amount)
        {
            return objTherap.updateTherapeuticAction(p_acte_id, p_acte_name, p_acte_amount);

        }
        public bool deleteTherapeuticAction(Int32 p_acte_id)
        {
            return objTherap.deleteTherapeuticAction(p_acte_id);
        }


        public DataSet showTherapeuticActionDDL()
        {
            return objTherap.showTherapeuticActionDDL();

        }

    }

}  