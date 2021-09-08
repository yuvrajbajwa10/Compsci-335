using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asignment_2SHITWEBAPI.Models;

namespace Asignment_2SHITWEBAPI.Data
{
    public interface ISHITRepo
    {
        IEnumerable<Users> GetAllUsers();
        IEnumerable<Orders> GetAllOrders();
        Users GetUsersById(String Username);
        Orders GetOrdersById(int Id);
        Users AddUsers(Users u);
        Orders AddOrders(Orders o);
        void DeleteUser(string userName);
        void DeleteOrder(int id);
        bool ValidLogin(string userName, string password);
        void SaveChanges();

    }
}
