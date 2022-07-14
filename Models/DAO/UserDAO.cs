using Common;
using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class UserDAO
    {
        OnlineShopDbContext db = null;
        public UserDAO()
        {
            db = new OnlineShopDbContext();
        }

        public int Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.Name = entity.Name;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.ProvinceID = entity.ProvinceID;
                user.DistrictID = entity.DistrictID;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
        public IEnumerable<User> ListAllpaging(string searchString, int Page, int PageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(u => u.Username.Contains(searchString) || u.Name.Contains(searchString));
            }
            return model.OrderByDescending(u => u.ID).ToPagedList(Page, PageSize);
        }
        public User GetByID(string Username)
        {
            return db.Users.SingleOrDefault(u => u.Username == Username);
        }
        public User ViewDetail(int ID)
        {
            return db.Users.Find(ID);
        }
        public int Login(string Username, string Password)
        {
            var result = db.Users.SingleOrDefault(u => u.Username == Username);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                    return -1;
                else
                {
                    if (result.Password == Password)
                        return 1;
                    else
                        return -2;
                }
            }
        }

        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = db.Users.SingleOrDefault(x => x.Username == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.GroupID == CommonConstants.ADMIN_GROUP || result.GroupID == CommonConstants.MOD_GROUP)
                    {
                        if (result.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.Password == passWord)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Password == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
        }

        public List<string> GetListCredential(string userName)
        {
            var user = db.Users.Single(x => x.Username == userName);
            var data = (from a in db.Credentials
                        join b in db.UserGroups on a.UserGroupID equals b.ID
                        join c in db.Roles on a.RoleID equals c.ID
                        where b.ID == user.GroupID
                        select new
                        {
                            RoleID = a.RoleID,
                            UserGroupID = a.UserGroupID
                        }).AsEnumerable().Select(x => new Credential()
                        {
                            RoleID = x.RoleID,
                            UserGroupID = x.UserGroupID
                        });
            return data.Select(x => x.RoleID).ToList();

        }

        public bool Delete(int ID)
        {
            try
            {
                var user = db.Users.Find(ID);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ChangeStatus(int ID)
        {
            var user = db.Users.Find(ID);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }

        public bool CheckUsername (string userName)
        {
            return db.Users.Count(x => x.Username == userName) > 0;
        }

        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
    }
}
