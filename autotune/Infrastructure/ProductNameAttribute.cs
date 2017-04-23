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
            string name = value as string;
            Product product = repo.Products.Where(p => p.Name == name).FirstOrDefault();
            if (product == null)
            {
                return true;
            }

            return false;
        }
    }
}