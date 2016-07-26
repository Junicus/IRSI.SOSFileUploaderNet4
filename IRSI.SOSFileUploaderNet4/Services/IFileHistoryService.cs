using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.SOSFileUploaderNet4.Services
{
    public interface IFileHistoryService
    {
        bool IsFileNew(string filename);
        void AddFile(string filename);
        Task LoadAsync();
        Task SaveAsync();
    }
}
