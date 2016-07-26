using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRSI.SOSFileUploaderNet4.Models.Common
{
    public class Store
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public Guid ConceptId { get; set; }
        public Guid RegionId { get; set; }
    }
}
