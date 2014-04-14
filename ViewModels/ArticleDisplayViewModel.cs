using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GardenArt.Core.Interfaces;
using GardenArt.Models;
using GardenArt.Models.Containers;

namespace GardenArt.ViewModels
{
    public class ArticleDisplayViewModel : IViewModel<ArticleDisplayViewModel>
    {
        //Holds one article Based On ID!
        private IEnumerable<ProductListItem> _OneDetailedArticle;
        private ProductContainer _ProductContainer;
        public ArticleDisplayViewModel GetViewModel()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ProductListItem> OneArticleFromID
        {
            get
            {
                return _OneDetailedArticle;
            }
            set
            {
                _OneDetailedArticle = value;
            }
        }

        public ProductContainer ProductContainer
        {
            get
            {
                return _ProductContainer;
            }
            set
            {
                _ProductContainer = value;
            }
        }
    }
}