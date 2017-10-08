using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftiDoc.Web.Api.Dto
{
    public class Databases
    {
        public virtual int id { get; set; }
        public virtual string text { get; set; }
        public virtual Guid Guid { get; set; }
        public virtual int SubdatabaseId { get; set; }
        public virtual string icon { get; set; }

        public virtual ICollection<Subdatabases> items { get; set; }
    }
}