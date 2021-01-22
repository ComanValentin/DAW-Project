using AutoMapper;
using CarPartShop.IRepositories;
using CarPartShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable enable

namespace CarPartShop.Services
{
    public class CarPartService
    {
        private readonly ICarPartRepository _carPartRepository;

        public CarPartService(ICarPartRepository carPartRepository)
        {
            _carPartRepository = carPartRepository;
        }

        public List<CarPart> GetAllCarParts()
        { 
            return _carPartRepository.GetAll();
        }

        public CarPart? GetCarPartById(int carPartId)
        {
            return _carPartRepository.GetById(carPartId);
        }
    }
}
