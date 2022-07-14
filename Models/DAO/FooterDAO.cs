﻿using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class FooterDAO
    {
        OnlineShopDbContext db = null;
        public FooterDAO()
        {
            db = new OnlineShopDbContext();
        }
        public Footer GetFooter()
        {
            return db.Footers.SingleOrDefault(f => f.Status == true);
        }
    }
}
