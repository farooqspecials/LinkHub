using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class AdminBs : BaseBs
    {
        public void ApproveOrReject(List<int> ids, string status)
        {
            using (TransactionScope Trans = new TransactionScope())
            {
                try
                {
                    foreach (var item in ids)
                    {
                        var myUrl = urlBs.GetByID(item);
                        myUrl.IsApproved = status;
                        urlBs.Update(myUrl);
                    }

                    Trans.Complete();
                }
                catch (Exception E1)
                {
                    throw new Exception(E1.Message);
                }
            }
        }
    }
}
