﻿using SistemaPrefeitura.Domain.DataContracts.Shared;
using SistemaPrefeitura.Domain.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrefeitura.Application.Services.Shared
{
    public class BaseService<TEntity, TRepository>
        where TEntity: Entity
        where TRepository: IBaseRepository<TEntity>
    {
        protected readonly TRepository _repository;

        protected BaseService(TRepository repository)
        {
            _repository = repository;
        }


        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.Now;
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            await _repository.RemoveByIdAsync(id);
            await _repository.SaveChangesAsync();

        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
            return entity;
        }

    }
}
