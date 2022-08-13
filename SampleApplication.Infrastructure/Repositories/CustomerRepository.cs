using Microsoft.EntityFrameworkCore;
using SampleApplication.Domain.Entities;
using SampleApplication.Domain.Interface;
using SampleApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SampleDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
