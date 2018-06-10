using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SMSONBD.MODEL.API
{
    public class USER
    {
        [StringLength(50),Required]
        public string USER_IDS { get; set; }
        [StringLength(50)]
        public string USER_FULL_NAME { get; set; }
        [StringLength(50)]
        public string EMAIL { get; set; }
        [StringLength(50)]
        public string PHONE { get; set; }
        [StringLength(50)]
        public string DISTRICT { get; set; }
        [StringLength(50)]
        public string POST_CODE { get; set; }
        [StringLength(50)]
        public string ADDRESS { get; set; }
        [StringLength(50)]
        public int SMS_CREDIT { get; set; }
        [StringLength(100),Required]
        public string HashCode { get; set; }
        [StringLength(50)]
        public string PENDING { set; get; }
        [StringLength(50)]
        public string S_SEND { set; get; }
        [StringLength(50)]
        public string TOTAL { set; get; }
    }
}
