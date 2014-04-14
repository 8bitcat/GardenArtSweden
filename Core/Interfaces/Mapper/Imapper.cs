using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GardenArt.Core.Interfaces.Mapper
{
    public interface Imapper
    {
        Tmodel MapViewModelToModel<TviewModel, Tmodel>(TviewModel source, Tmodel destination)
            where Tmodel : class, IModel<Tmodel>, new()
            where TviewModel : class, IViewModel<TviewModel>, new();

        TviewModel MapModelToViewModel<Tmodel, TviewModel>(Tmodel source, TviewModel destination)
            where TviewModel : class, IViewModel<TviewModel>, new()
            where Tmodel : class, IModel<Tmodel>, new();

    }
}