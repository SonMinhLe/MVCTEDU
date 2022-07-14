using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ProductDAO
    {
        OnlineShopDbContext db = null;

        public ProductDAO()
        {
            db = new OnlineShopDbContext();
        }
        public List<Product> ListNewProduct(int top)
        {

            return db.Products.OrderByDescending(p => p.CreatedDate).Take(top).ToList();

        }

        public List<Product> ListByCategoryID(long categoryID, ref int TotalRecord, int pageIndex = 1, int pageSize = 2)
        {
            TotalRecord = db.Products.Where(p => p.CategoryID == categoryID).Count();
            var model =  db.Products.Where(p => p.CategoryID == categoryID).OrderByDescending(p => p.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }

        public List<Product> ListFeatureproduct(int top)
        {
            return db.Products.Where(p => p.TopHot != null && p.TopHot < DateTime.Now).OrderByDescending(p => p.CreatedDate).ToList();
        }

        public List<Product> ListRelatedProduct(long productID)
        {
            var product = db.Products.Find(productID);
            return db.Products.Where(p => p.ID != productID && p.CategoryID == product.CategoryID).ToList();
        }

        public Product ViewDetail(long ID)
        {
            return db.Products.Find(ID);
        }

        public List<string> ListName (string searchString)
        {
            return db.Products.Where(p => p.Name.Contains(searchString)).Select(p => p.Name).ToList();
        }

        public List<Product> Search(string searchString, ref int TotalRecord, int pageIndex = 1, int pageSize = 2)
        {
            TotalRecord = db.Products.Where(p => p.Name.Contains(searchString)).Count();
            var model = db.Products.Where(p => p.Name.Contains(searchString)).OrderByDescending(p => p.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }
    }
}
