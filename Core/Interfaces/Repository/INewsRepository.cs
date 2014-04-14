﻿using GardenArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenArt.Core.Interfaces.Repository
{
    interface INewsRepository
    {
        NewsListItem FetchNewsById(int id);
        
    }
}
