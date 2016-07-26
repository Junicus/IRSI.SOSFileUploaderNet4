using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRSI.SOSFileUploaderNet4.Models.Common;
using IRSI.SOSFileUploaderNet4.Models.SOS;

namespace IRSI.SOSFileUploaderNet4.Services
{
    public interface ISOSLineParserService
    {
        SOSItem Parse(string line, Store store, DateTime businessDate);
    }
}
