using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public interface IApplicationDisplay
    {
        IEnumerable<ApplicationDisplay> ApplicationDisplays { get; }
        void SaveApplicationDisplay(ApplicationDisplay applicationDisplay);
    }
}
