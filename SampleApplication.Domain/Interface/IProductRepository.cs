using SampleApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Domain.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
