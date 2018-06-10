using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSONBD.MODEL
{
    [Serializable]
    public class SMSON_GROUP
    {
        public int GROUP_ID { set; get; }
        public string GROUP_NAME { set; get; }
        public string USER_IDS { set; get; }
        public int IS_ACTIVE { set; get; }

    }
}
