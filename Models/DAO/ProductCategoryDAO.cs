using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ProductCategoryDAO
    {
        OnlineShopDbContext db = null;

        public ProductCategoryDAO()
        {
            db = new OnlineShopDbContext();
        }

         public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.Where(pc => pc.Status == true).OrderBy(pc => pc.DisplayOrder).ToList();
        }


        public ProductCategory ViewDeTail(long ID)
        {
            return db.ProductCategories.Find(ID);
        }
    }
}
