
using GardenArt.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GardenArt.Models
{
    public class OrderModels
    {
        public OrderModels()
        {
            if (this.DropDownList == null)
            {
                Entities gadb = new Entities();

                var items = (IEnumerable<SelectListItem>)gadb.tCategory
                        .GroupBy(x => x.Name)
                        .Select(g => g.FirstOrDefault())
                        .Select(x => new SelectListItem() { Value = SqlFunctions.StringConvert((double)x.CategoryID), Text = x.Name });

                this.DropDownList = new SelectList
                (
                    items, "Value", "Text"
                );
            }
        }

        public SelectList DropDownList { get; set; }
    }
}