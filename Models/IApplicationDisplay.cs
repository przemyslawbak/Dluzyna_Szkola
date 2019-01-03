using System.Collections.Generic;

namespace DluzynaSzkola2.Models
{
    public interface IApplicationDisplay
    {
        IEnumerable<ApplicationDisplay> ApplicationDisplays { get; }
        void SaveApplicationDisplay(ApplicationDisplay applicationDisplay);
    }
}
