using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorAutomationApp.DataAccess.Abstract;
using BlazorAutomationApp.EfCore;

namespace BlazorAutomationApp.Business
{
    internal class ProductManager
    {
        Repository<Product> productRepository = new Repository<Product>();

        public List<Product> List()
        {
            return productRepository._List();
        }

        public int Insert(Product p)
        {
            try
            {
                productRepository._Insert(p);
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public int Update(Product p)
        {
            try
            {
                Product product = productRepository._Find(x => x.Id == p.Id);
                product.Name = p.Name;
                productRepository._Update(product);
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public int Delete(int p)
        {
            try
            {
                Product product = productRepository._Find(x => x.Id == p);
                productRepository._Delete(product);
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public List<Product> FilterList(string p)
        {
            return productRepository._FilterList(x => x.Id.ToString().ToLower().Contains(p) || x.Name.ToLower().Contains(p) || x.Price.ToString().ToLower().Contains(p) || x.Description.ToLower().Contains(p)).ToList();
        }

        public Product GetById(int id)
        {
            return productRepository._GetById(id);
        }
    }
}
