using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GardenArt.Core.Interfaces
{
    interface IFactory
    {
        T BuildViewModel<T>() where T : class, IViewModel<T>, new();
        T BuildViewModel<Tinput, T>(Tinput id) where T : class, IViewModel<T>, new();
        T BuildModel<T>() where T : class, IModel<T>, new();
        T BuildModel<Tinput, T>(Tinput id) where T : class, new();

        /// <summary>Creates a Model and a ViewModel. After creation the values in the model get's mapped to the viewmodel.
        /// <para> 
        /// </para>
        /// <seealso cref="GardenArt.Domain.Factory for concrete implementation."/>
        /// </summary> 

        TypeViewModel BuildAndMap<TypeModel, TypeViewModel>()
            where TypeModel : class, IModel<TypeModel>, new()
            where TypeViewModel : class, IViewModel<TypeViewModel>, new();

        /// <summary>Creates a Model ID and a ViewModel. After creation the values in the model get's mapped to the viewmodel.
        /// <para> 
        /// </para>
        /// <seealso cref="GardenArt.Domain.Factory for concrete implementation."/>
        /// </summary> 
        
        TypeViewModel BuildAndMap<TypeModel, TypeViewModel>(int id)
            where TypeModel : class, IModel<TypeModel>, new()
            where TypeViewModel : class, IViewModel<TypeViewModel>, new();

    }
}
