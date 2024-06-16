using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithObjectsSpecification : BaseSpecification<Product>
    {
        public ProductsWithObjectsSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        public ProductsWithObjectsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}