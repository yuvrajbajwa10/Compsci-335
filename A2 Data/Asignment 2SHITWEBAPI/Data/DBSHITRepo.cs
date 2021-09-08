using Asignment_2SHITWEBAPI.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asignment_2SHITWEBAPI.Data
{
    public class DBSHITRepo : ISHITRepo
    {
        private readonly SHITDBContext _dbContext;
        
        public DBSHITRepo(SHITDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Orders AddOrders(Orders o)
        {
            EntityEntry<Orders> order = _dbContext.Orders.Add(o);
            Orders returnOrder = order.Entity;
            _dbContext.SaveChanges();
            return returnOrder;
        }

        public Users AddUsers(Users u)
        {
            EntityEntry<Users> user = _dbContext.Users.Add(u);
            Users returnUser = user.Entity;
            _dbContext.SaveChanges();
            return returnUser;
        }

        public void DeleteOrder(int id)
        {
            Orders Order = _dbContext.Orders.FirstOrDefault(e => e.Id == id);
            if (Order != null)
            {
                _dbContext.Orders.Remove(Order);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteUser(string userName)
        {
            Users User = _dbContext.Users.FirstOrDefault(e => e.UserName == userName);
            if (User != null)
            {
                _dbContext.Users.Remove(User);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Orders> GetAllOrders()
        {
            IEnumerable<Orders> AllOrders = _dbContext.Orders.ToList<Orders>();
            return AllOrders;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            IEnumerable<Users> AllUsers = _dbContext.Users.ToList<Users>();
            return AllUsers;
        }

        public Orders GetOrdersById(int Id)
        {
            Orders Order = _dbContext.Orders.FirstOrDefault(e => e.Id == Id);
            return Order;
        }

        public Users GetUsersById(string Username)
        {
            Users User = _dbContext.Users.FirstOrDefault(e => e.UserName == Username);
            return User;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public bool ValidLogin(string userName, string password)
        {
            Users u = _dbContext.Users.FirstOrDefault(e => e.UserName == userName && e.Password == password);
            if (u == null)
                return false;
            else
                return true;
        }
    }
}
