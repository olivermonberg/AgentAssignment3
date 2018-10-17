using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentAssignment3
{
    public class Specialities : ObservableCollection<string>
    {
        public Specialities()
        {
            Add("Assassination");
            Add("Martinis");
            Add("Ladies");
            Add("Goldfinger");
        }
    }
}
