using SampleApplication.Domain.Entities;
using SampleApplication.Domain.Interface;
using SampleApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(SampleDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
