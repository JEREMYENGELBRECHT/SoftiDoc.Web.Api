using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftiDoc.Web.Api.Dto
{
    public class Cabinets
    {
        public virtual int id { get; set; }
        public virtual int pid { get; set; }
        public virtual string Database { get; set; }
        public virtual Guid SubdatabaseGuid { get; set; }
        public virtual string text { get; set; }
        public virtual Guid Guid { get; set; }
        public virtual string icon { get; set; }

    }
}