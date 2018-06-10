using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace SMSONBD.MODEL.API
{
    public class SEND_SMS
    {
        [StringLength(100),Required]
        public string HASHCODE { set; get; }
        [StringLength(50), Required]
        public string USER_IDS { set; get; }
        [StringLength(50), Required]
        public string PASSWORD { set; get; }
        [StringLength(50), Required]
        public string NUMBER { set; get; }
        [StringLength(5000), Required]
        public string MESSAGE { set; get; }

    }
}
