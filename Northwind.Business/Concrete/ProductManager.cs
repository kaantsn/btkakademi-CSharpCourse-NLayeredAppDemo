using Northwind.Business.Absrtact;
using Northwind.DataAccess.Absrtact;
using Northwind.DataAccess.Concrete;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //Business code

            return _productDal.GetAll();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }

        public List<Product> GetProductsByProductName(string productName)
        {
            return _productDal.GetAll(p=>p.ProductName.ToLower().Contains(productName.ToLower()));
        }

        List<Product> IProductService.GetProductsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Uptade(Product product)
        {
           _productDal.Uptade(product);
        }

        public void Delete(Product product)
        {
            try
            {
                _productDal.Delete(product);
            }
            catch
            {

                throw new Exception("Silme gerçekleşemedi!");
            }
        }
    }
}
