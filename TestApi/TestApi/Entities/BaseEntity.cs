using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Entities
{
    /// <comment>
    /// Commentor: Md Amanul Haque
    /// Common properties should be in a separate file
    /// </comment>
    public class BaseEntity
    {

        public int Id { get; set; }
        /*
         * Always use the following entities for db entities
         */
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
