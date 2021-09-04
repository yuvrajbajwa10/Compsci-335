using Microsoft.EntityFrameworkCore.ChangeTracking;
using SHIT_Web_API_A1_YBAJ161.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SHIT_Web_API_A1_YBAJ161.Data
{
    public class DBShitWebAPIRepo : IShitWebAPIRepo
    {
        private readonly ShitWebAPIDBContext _dbContext;

        public DBShitWebAPIRepo(ShitWebAPIDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Products AddProduct(Products p)
        {
            EntityEntry<Products> product = _dbContext.Products.Add(p);
            Products returnproduct = product.Entity;
            _dbContext.SaveChanges();
            return returnproduct;
        }

        public Staff AddStaff(Staff s)
        {
            EntityEntry<Staff> Staff = _dbContext.Staff.Add(s);
            Staff returnStaff = Staff.Entity;
            _dbContext.SaveChanges();
            return returnStaff;
        }

        public void DeleteProduct(int id)
        {
            Products Product = _dbContext.Products.FirstOrDefault(e => e.Id == id);
            if (Product != null)
            {
                _dbContext.Products.Remove(Product);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteStaff(int id)
        {
            Staff StaffToDelete = _dbContext.Staff.FirstOrDefault(e => e.Id == id);
            if (StaffToDelete != null)
            {
                _dbContext.Staff.Remove(StaffToDelete);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Products> GetAllProducts()
        {
            IEnumerable<Products> AllProducts = _dbContext.Products.ToList<Products>();
            return AllProducts;
        }

        public IEnumerable<Staff> GetAllStaff()
        {
            IEnumerable<Staff> AllStaff = _dbContext.Staff.ToList<Staff>();
            return AllStaff;
        }

        public Products GetProductById(int id)
        {
            Products Product = _dbContext.Products.FirstOrDefault(e => e.Id == id);
            return Product;
        }

        public Staff GetStaffById(int id)
        {
            Staff StaffMember = _dbContext.Staff.FirstOrDefault(e => e.Id == id);
            return StaffMember;
        }
        public Comments AddComments(Comments c)
        {
            EntityEntry<Comments> comments = _dbContext.Comments.Add(c);
            Comments returnComments = comments.Entity;
            _dbContext.SaveChanges();
            return returnComments;
        }

        public IEnumerable<Comments> Get5Comments()
        {
            IEnumerable<Comments> AllComments = _dbContext.Comments.ToList<Comments>();
            return AllComments.TakeLast(5);
        }

        public Comments GetComments(int id)
        {
            Comments comment = _dbContext.Comments.FirstOrDefault(e => e.Id == id);
            return comment;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

       
    }
}
