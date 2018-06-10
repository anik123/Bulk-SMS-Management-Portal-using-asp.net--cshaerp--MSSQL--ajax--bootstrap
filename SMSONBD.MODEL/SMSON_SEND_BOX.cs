using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSONBD.MODEL
{
    [Serializable]
    public class SMSON_SEND_BOX
    {
        public int SMS_BOX_NUMBER { set; get; }
        public string MOBILE_NUMBER { set; get; }
        public string USER_IDS { set; get; }
        public string SMS_TEXT { set; get; }
        public int SMS_STATUS { set; get; }
        public int GROUP_ID { set; get; }
        public DateTime MAKE_DT { set; get; }

        //Extra 

        public string GROUP_NAME { set; get; }
        public string STATUS { set; get; }
    }
}
