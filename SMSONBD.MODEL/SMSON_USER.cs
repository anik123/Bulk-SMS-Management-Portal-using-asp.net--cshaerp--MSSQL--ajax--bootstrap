using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSONBD.MODEL
{
    [Serializable]
    public class SMSON_USER
    {

        public string USER_IDS { get; set; }
        public string USER_FULL_NAME { get; set; }

        public string PASSWORD { get; set; }
        public string EMAIL { get; set; }
        public string PHONE { get; set; }
        public string DISTRICT { get; set; }
        public string POST_CODE { get; set; }
        public string ADDRESS { get; set; }
        public int SMS_CREDIT { get; set; }
        public int IS_ACTIVE { get; set; }
        public string HashCode { get; set; }

        //Extra

        public string SPEND { set; get; }
        public string TOTAL_MESSAGE { set; get; }
        public string TOTAL_CONTACTS { set; get; }


    }
}
