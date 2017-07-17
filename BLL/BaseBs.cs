﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaseBs
    {
        public CategoryBs cateogryBs { get; set; }
        public UrlBs urlBs { get; set; }

        public UserBs userBs { get; set; }

        public BaseBs()
        {
            cateogryBs = new CategoryBs();
            userBs = new UserBs();
            urlBs = new UrlBs();
        }
    }
}
