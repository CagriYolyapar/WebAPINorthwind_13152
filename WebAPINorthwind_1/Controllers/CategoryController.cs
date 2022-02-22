using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPINorthwind_1.DesignPatterns.SingletonPattern;
using WebAPINorthwind_1.DTOClasses;
using WebAPINorthwind_1.Models;

namespace WebAPINorthwind_1.Controllers
{
    public class CategoryController : ApiController
    {
        


        NorthwindEntities _db;

        public CategoryController()
        {
            _db = DBTool.DBInstance;
        }


        [HttpGet]
        public List<CategoryDTO> ListCategories()
        {
            //1. => Veritabanında ürünü olmayan kategorileri bulup _db.Categories.Where(x=>x.Products == null) 

            //2. => SSMS'te Products'i null olan Category'lere default constraint verilecek...

            //3=> Category sayısı kadar  CategoryDTO instance'i alıp CategoryDTO ozelliklerini bir Foreach döngüsünde veritabanı Kategorilerinde dönerek elle mapleme yapmanız


           // List<CategoryDTO> cDtos = new List<CategoryDTO>(); //Products'ı olmayanlar


            return _db.Categories.Select(x => new CategoryDTO
            {
                Name = x.CategoryName,
                ID = x.CategoryID,
                Description = x.Description,
                ProductCount = x.Products.Count
            }).ToList();
        }

        [HttpGet]
        public CategoryDTO BringCategory(int id)
        {
            return _db.Categories.Where(x => x.CategoryID == id).Select(x => new CategoryDTO
            {
                Name = x.CategoryName,
                ID = x.CategoryID,
                Description = x.Description,
                ProductCount = x.Products.Count
            }).FirstOrDefault();
        }


        [HttpPost]
        public List<CategoryDTO> AddCategory(Category item)
        {
            _db.Categories.Add(item);
            _db.SaveChanges();
            return ListCategories();
        }

        [HttpDelete]
        public List<CategoryDTO> DeleteCategory(int id)
        {
            _db.Categories.Remove(_db.Categories.Find(id));
            _db.SaveChanges();
            return ListCategories();
        }

        [HttpPut]
        public List<CategoryDTO> UpdateCategory(Category item)
        {
            Category guncellenecek = _db.Categories.Find(item.CategoryID);
            guncellenecek.CategoryName = item.CategoryName;
            guncellenecek.Description = item.Description;
            _db.SaveChanges();
            return ListCategories();
        }

        [HttpGet]
        public List<CategoryDTO> SearchCategory(string item)
        {
            return _db.Categories.Where(x => x.CategoryName.Contains(item)).Select(x => new CategoryDTO
            {
                ID = x.CategoryID,
                Name = x.CategoryName,
                Description = x.Description
            }).ToList();
        }




    }
}
