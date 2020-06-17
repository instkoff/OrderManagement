using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderManagement.DataAccess;
using OrderManagement.DataAccess.Entities;
using OrderManagement.Domain.Contracts;
using OrderManagement.Domain.Contracts.Models;
using OrderManagement.Domain.Contracts.Services;

namespace OrderManagement.Domain.Implementation.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public ProviderService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(ProviderModel providerModel)
        {
            var providerEntity = _mapper.Map<ProviderEntity>(providerModel);
            var providerCheck = await _dbRepository.Get<ProviderEntity>(p => p.Name == providerModel.Name).FirstOrDefaultAsync();
            if (providerCheck != null)
            {
                return 0;
            }
            await _dbRepository.AddAsync(providerEntity);
            await _dbRepository.SaveChangesAsync();
            return providerEntity.Id;
        }

        public List<ProviderModel> GetAll()
        {
            var providerCollection = _dbRepository.GetAll<ProviderEntity>();
            if (!providerCollection.Any())
            {
                return null;
            }
            var providerModels = _mapper.Map<List<ProviderModel>>(providerCollection);
            return providerModels;
        }

        public async Task<ProviderModel> Get(int id)
        {
            var providerEntity = await _dbRepository.Get<ProviderEntity>(x => x.Id == id).FirstOrDefaultAsync();
            var providerModel = _mapper.Map<ProviderModel>(providerEntity);
            return providerModel;
        }

    }
}
