using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyIntranetPortal.Models
{
    public class ViewModel
    {

        public CMS_User users { get; set; }
        public IEnumerable<CMS_Role> roles { get; set; }
    }
}