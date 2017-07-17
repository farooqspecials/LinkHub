using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SecurityBs
    {
        public CategoryBs cateogryBs { get; set; }
        public UrlBs urlBs { get; set; }

        public UserBs userBs { get; set; }

        public SecurityBs()
        {
            cateogryBs = new CategoryBs();
            userBs = new UserBs();
            urlBs = new UrlBs();
        }
    }
}
