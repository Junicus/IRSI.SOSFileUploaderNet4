using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.SOSFileUploaderNet4.Models.Common;
using IRSI.SOSFileUploaderNet4.Models.SOS;

namespace IRSI.SOSFileUploaderNet4.Services
{
    public interface ISOSFileParserService
    {
        Task<IList<SOSItem>> ParseAsync(string path, Store store);
    }
}
