﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Repository.RepositoryPattern;
using AutoMapper;
using Domain.Exceptions;

namespace Repository.DatabaseSeedLoader
{
    public  class DatabaseSeedLoader : IDatabaseSeedLoader
    {
         readonly IMapper _mapper;
         readonly IRepository<Domain.Entity.Client> _clientRepository;
        readonly IRepository<Domain.Entity.Car> _carRepository;

         List<Client> clients = new()
        {

             new Client { IsActive = true, Name = "Data", Surname = "Rostiashvili", IDNumber = "11112222333", DateOfBirth = DateTime.Now, ClientContactInfo = new ClientContactInfo { IsActive = true, Address = "misamarti", Email = "s@g.c", PhoneNumber = "555666777" } },
             new Client { IsActive = true, Name = "Giorgi", Surname = "Edisherashvili", IDNumber = "11112222533", DateOfBirth = DateTime.Now, ClientContactInfo = new ClientContactInfo { IsActive = true, Address = "misamarti", Email = "s@g.c", PhoneNumber = "555666777" } },
             new Client { IsActive = true, Name = "Vasil", Surname = "Wantiani", IDNumber = "11412222333", DateOfBirth = DateTime.Now, ClientContactInfo = new ClientContactInfo { IsActive = true, Address = "misamarti", Email = "s@g.c", PhoneNumber = "555666777" } },
             new Client { IsActive = true, Name = "Toma", Surname = "axalaia", IDNumber = "11112222733", DateOfBirth = DateTime.Now, ClientContactInfo = new ClientContactInfo { IsActive = true, Address = "misamarti", Email = "s@g.c", PhoneNumber = "555666777" } },
             new Client { IsActive = true, Name = "Vano", Surname = "Grdzelishvili", IDNumber = "11112222313", DateOfBirth = DateTime.Now, ClientContactInfo = new ClientContactInfo { IsActive = true, Address = "misamarti", Email = "s@g.c", PhoneNumber = "555666777" } }


         };
        List<Domain.Entity.Car> cars = new()
        {
            new Domain.Entity.Car { IsActive = true, Brand = "Honda", Model = "CR-V", ProductionYear = 2001, SellingPrice = 2500.00m, StateNumber="ZR397RZ",  VIN = "11112222333344445" },
            new Domain.Entity.Car { IsActive = true, Brand = "Mercedes", Model = "CLS", ProductionYear = 2001, SellingPrice = 2100.00m, StateNumber = "ZR367RZ", VIN = "11112222353344445" },
            new Domain.Entity.Car { IsActive = true, Brand = "Honda", Model = "FIT", ProductionYear = 2001, SellingPrice = 2500.00m, StateNumber = "ZR117RZ", VIN = "11112322333344445" },
            new Domain.Entity.Car { IsActive = true, Brand = "FORD", Model = "F-150", ProductionYear = 2021, SellingPrice = 62500.00m, StateNumber = "ZR397RT", VIN = "11112922333344445" },

        };

        public DatabaseSeedLoader(IRepository<Domain.Entity.Client> clientRepository,
            IRepository<Domain.Entity.Car> carRepository,
            IMapper mapper) {

            _clientRepository = clientRepository;
            _carRepository = carRepository; 
            _mapper = mapper;
        }
        void LoadData()
        {
            clients[0].Cars.Add(cars[0]);
            clients[0].Cars.Add(cars[1]);
            clients[1].Cars.Add(cars[2]);
            clients[2].Cars.Add(cars[3]);

            //cars[0].Client = _mapper.Map<Domain.Entity.Client>(clients[0]);
            //cars[1].Client = _mapper.Map<Domain.Entity.Client>(clients[0]);
            //cars[2].Client = _mapper.Map<Domain.Entity.Client>(clients[1]);
            //cars[3].Client = _mapper.Map<Domain.Entity.Client>(clients[2]);

        }
        public async Task SeedData()
        {
            LoadData();

            if (_clientRepository.GetAll().Any())
                throw new DatabaseAlreadySeededException("Database is already seeded");

            foreach (var client in clients)
                await _clientRepository.InsertAsync(client);


        }
    }
}
