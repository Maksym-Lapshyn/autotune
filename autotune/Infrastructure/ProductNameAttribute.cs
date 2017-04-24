using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using autotune.Models;

namespace autotune.Infrastructure
{
    public class ProductNameAttribute : ValidationAttribute
    {
        ProjectRepository repo = new ProjectRepository();
        public override bool IsValid(object value)
        {
            Product newProduct = value as Product;
            Product oldProduct = repo.Products.Where(p => p.Name == newProduct.Name).FirstOrDefault();
            if (oldProduct != null)
            {
                if (oldProduct.Id != newProduct.Id)
                {
                    return false;
                }
            }

            return true;
        }
    }
}