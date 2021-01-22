using CarPartShop.IRepositories;
using CarPartShop.Models;
using CarPartShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartShop.Repositories
{
    public class CarPartRepository: GenericRepository<CarPart>, ICarPartRepository
    {
        public CarPartRepository(CarPartShopContext context): base(context)
        {

        }
    }
}
