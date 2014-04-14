using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GardenArt.Infrastructure.Uploaders
{
    public interface IUploader
    {
        IEnumerable<HttpPostedFileBase> files { get; set; }
    }
}
