using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRSI.SOSFileUploaderNet4.Models.SOS
{
    public class SOSItemsPost
    {
        public Guid StoreId { get; set; }
        public string Filename { get; set; }
        public DateTime BusinessDate { get; set; }
        public IList<SOSItem> SOSItems { get; set; }
    }
}
