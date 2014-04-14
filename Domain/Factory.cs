using GardenArt.Core.Interfaces;
using GardenArt.Core.Interfaces.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GardenArt.Domain.Factory
{
    public class Factory : IFactory
    {
        private Imapper mapper = new Mapper();
     
        //NOT NEEDED IN ACCTUAL IMPLEMENTATION!--->
        public T BuildDetailedViewModel<Tinput, T>(Tinput id) where T : class, IViewModel<T>, new()
        {
            return (T)Activator.CreateInstance(typeof(T), id);
        }
        //NOT NEEDED IN ACCTUAL IMPLEMENTATION!--->
        public T BuildDetailedModel<Tinput, T>(Tinput id) where T : class, new()
        {
            return (T)Activator.CreateInstance(typeof(T), id);
        }

        //Tighten coupling by only allowing class Implementing IViewModel to use BuildViewModel!
        T IFactory.BuildViewModel<T>() 
        {
            return (T)Activator.CreateInstance<T>();
        }
        //Using overloaded CTORS(constructors) we can achieve a detailed build of a ViewModel
        T IFactory.BuildViewModel<Tinput, T>(Tinput id)
        {
            return (T)Activator.CreateInstance(typeof(T), id);
        }
        //Tighten coupling by only allowing classa Implementing IModel to use BuildModel!
        T IFactory.BuildModel<T>()
        {
            return (T)Activator.CreateInstance<T>();
        }
        //Using overloaded CTORS(constructors) we can achieve a detailed build of a Model
        T IFactory.BuildModel<Tinput, T>(Tinput id) 
        {
            return (T)Activator.CreateInstance(typeof(T), id);
        }
 
        public TypeViewModel BuildAndMap<TypeModel, TypeViewModel>()
            //Constraint for BOTH types
                where TypeModel : class, IModel<TypeModel>, new()
                where TypeViewModel : class, IViewModel<TypeViewModel>, new()
        {
            //Create the isntaces needed to build N map!
            TypeModel model = Activator.CreateInstance<TypeModel>();
            TypeViewModel viewModel = Activator.CreateInstance<TypeViewModel>();
            viewModel = mapper.MapModelToViewModel<TypeModel, TypeViewModel>(model, viewModel);
            return viewModel;
        }

        public TypeViewModel BuildAndMap<TypeModel, TypeViewModel>(int id)
            //Constraint for BOTH types
            where TypeModel : class, IModel<TypeModel>, new()
            where TypeViewModel : class, IViewModel<TypeViewModel>, new()
        {
            //Create the isntaces needed to build N map!
            TypeModel model = (TypeModel)Activator.CreateInstance(typeof(TypeModel), id);
            TypeViewModel viewModel = Activator.CreateInstance<TypeViewModel>();
            viewModel = mapper.MapModelToViewModel<TypeModel, TypeViewModel>(model, viewModel);
            return viewModel;
        }


    }
}
