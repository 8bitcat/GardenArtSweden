using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GardenArt.Core.Interfaces
{
    //LOL @ MAKING INTERFACES PUBLIC!
    public interface IViewModel<T>
    {
        T GetViewModel();
    }
}
