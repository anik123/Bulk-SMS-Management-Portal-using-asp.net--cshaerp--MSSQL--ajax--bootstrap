using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSONBD.MODEL
{
    public class SMSON_TRANSACTION
    {
        public int TRANSACTION_ID { set; get; }
        public int TRANSACTION_NUMBER { set; get; }
        public int PACKAGE_ID { set; get; }
        public int TRANSACTION_TOTAL { set; get; }
        public string USER_IDS { set; get; }
        public int TRANSACTION_DATE { set; get; }
    }
}
