using GardenArt.Core.Interfaces.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GardenArt.Domain
{
    public class Mapper : Imapper
    {
        Tmodel Imapper.MapViewModelToModel<TviewModel, Tmodel>(TviewModel source, Tmodel destination)
        {
            var destProperties = destination.GetType().GetProperties();

            foreach (var sourceProperty in source.GetType().GetProperties())
            {
                foreach (var destProperty in destProperties)
                {
                    if (destProperty.Name == sourceProperty.Name && destProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                    {
                        destProperty.SetValue(destination, sourceProperty.GetValue(
                            source, new object[] { }), new object[] { });

                        break;
                    }
                }
            }

            return destination;
        }

        TviewModel Imapper.MapModelToViewModel<Tmodel, TviewModel>(Tmodel source, TviewModel destination)
        {
            var destProperties = destination.GetType().GetProperties();

            foreach (var sourceProperty in source.GetType().GetProperties())
            {
                foreach (var destProperty in destProperties)
                {
                    if (destProperty.Name == sourceProperty.Name && destProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                    {
                        destProperty.SetValue(destination, sourceProperty.GetValue(
                            source, new object[] { }), new object[] { });

                        break;
                    }
                }
            }

            return destination;
        }
    }
}