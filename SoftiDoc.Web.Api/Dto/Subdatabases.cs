using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftiDoc.Web.Api.Dto
{
    public class Subdatabases
    {
        public virtual int id { get; set; }
        public virtual int pid { get; set; }
        public virtual string Databasename { get; set; }
        public virtual string text { get; set; }
        public virtual Guid Guid { get; set; }
        public virtual int CabinetId { get; set; }
        public virtual string icon { get; set; }

        public virtual ICollection<Cabinets> items { get; set; }

    }
}