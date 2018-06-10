using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace SMSONBD.MODEL.API
{
    public class STATUS
    {
        [StringLength(100), Required]
        public string MESSAGE { set; get; }
    }
}
