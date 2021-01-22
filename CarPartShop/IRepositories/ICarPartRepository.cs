using CarPartShop.Models.Entities;
using CarPartShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartShop.IRepositories
{
    public interface ICarPartRepository: IGenericRepository<CarPart>
    {
    }
}
