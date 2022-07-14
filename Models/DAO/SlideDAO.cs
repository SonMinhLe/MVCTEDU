using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class SlideDAO
    {
        OnlineShopDbContext db = null;

        public SlideDAO()
        {
            db = new OnlineShopDbContext();
        }
        
        public List<Slide> ListAll()
        {
            return db.Slides.Where(s => s.Status == true).OrderBy(s => s.DisplayOrder).ToList();
        }
    }
}
