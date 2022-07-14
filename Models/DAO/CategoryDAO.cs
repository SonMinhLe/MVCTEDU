using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class CategoryDAO
    {
        OnlineShopDbContext db = null;

        public CategoryDAO()
        {
            db = new OnlineShopDbContext();
        }

        public List<Category> ListAll()
        {
            return db.Categories.Where(c => c.Status == true).ToList();
        }

        public ProductCategory ViewDetail(long categoryID)
        {
            return db.ProductCategories.Find(categoryID);
        } 
        
        
    }
}
