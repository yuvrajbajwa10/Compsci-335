using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SHIT_Web_API_A1_YBAJ161.Models;

namespace SHIT_Web_API_A1_YBAJ161.Data
{
    public interface IShitWebAPIRepo
    {
        IEnumerable<Staff> GetAllStaff();
        IEnumerable<Products> GetAllProducts();
        IEnumerable<Comments> Get5Comments();
        Staff GetStaffById(int Id);
        Products GetProductById(int Id);
        Comments GetComments(int Id);
        Staff AddStaff(Staff s);
        Comments AddComments(Comments s);
        Products AddProduct(Products p);
        void DeleteStaff(int id);
        void DeleteProduct(int id);
        void SaveChanges();


    }
}
