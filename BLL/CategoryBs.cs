using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryBs
    {

        private CategoryDb obj;

        public CategoryBs()
        {
            obj = new CategoryDb();
        }

        public IEnumerable<tbl_Category> GetALL()
        {
            return obj.GetALL();
        }

        public tbl_Category GetByID(int Id)
        {
            return obj.GetByID(Id);
        }
        public void Insert(tbl_Category cat)
        {
            obj.Insert(cat);
        }
        public void Delete(int Id)
        {
            obj.Delete(Id);
        }
        public void update(tbl_Category cat)
        {
            obj.Update(cat);
        }
       
    

    }
}

