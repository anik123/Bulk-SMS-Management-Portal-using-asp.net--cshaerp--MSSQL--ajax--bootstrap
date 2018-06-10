using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSONBD.MODEL
{
    [Serializable]
    public class SMSON_CONTACT
    {
        public int CONTACT_ID { set; get; }
        public string CONTACT_NAME { set; get; }
        public int GROUP_ID { set; get; }
        public string CONTACT_NUMBER { set; get; }
        public string USER_IDS { set; get; }
        public string GROUP_NAME { set; get; }
        public DateTime MAKE_DT { set; get; }

        public int SMS_CREDIT { set; get; }
    }
}
