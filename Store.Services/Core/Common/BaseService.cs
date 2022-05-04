using AutoMapper;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Store.Data.Infrastructures;
using Store.Data.Repositories.Common;
using Store.ViewModels.Common;

namespace Store.Services.Core
{
    public interface IBaseService<E, F, V, A, U> where E : class where F : class where V : class where A : class where U : class
    {
        Task<ResultModel<E>> Add(A model);

        Task<ResultModel<E>> Update(U model, int id);

        Task<ResultModel> Delete(int id);

        Task<ResultModel<V>> Get(int id);

        Task<PagingModel<V>> GetPagedResult(F filter, int userId);
    }

    /*
        Generic
        - E: Entity
        - F: Filter model
        - V: View model
        - A: Add model
        - U: Update model
    */
    public class BaseService<E, F, V, A, U>: IBaseService<E, F, V, A, U> where E : class where F : class where V : class where A : class where U : class
    {
        private readonly IBaseRepository<E> _repository;
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;

        public BaseService(IMapper mapper, IUnitOfWork unitOfWork, IBaseRepository<E> repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public virtual async Task<ResultModel<E>> Add(A model)
        {
            var result = new ResultModel<E>();

            var entity = _mapper.Map<A, E>(model);

            _repository.Add(entity);
            await _repository.DbContext.SaveChangesAsync();

            result.Succeed = true;
            result.Data = entity;

            return result;
        }

        public virtual async Task<ResultModel<E>> Update(U model, int id)
        {
            var result = new ResultModel<E>();

            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException();

            entity = _mapper.Map<U, E>(model, entity);

            _repository.Update(entity);
            await _repository.DbContext.SaveChangesAsync();

            result.Succeed = true;
            result.Data = entity;

            return result;
        }

        public virtual async Task<ResultModel> Delete(int id)
        {
            var result = new ResultModel();
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException();

            _repository.Delete(id);
            await _repository.DbContext.SaveChangesAsync();

            result.Succeed = true;
            result.Data = id;

            return result;
        }

        public virtual async Task<ResultModel<V>> Get(int id)
        {
            var result = new ResultModel<V>();

            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException();

            var entityModel = _mapper.Map<E, V>(entity);

            result.Succeed = true;
            result.Data = entityModel;

            return result;
        }

        public virtual async Task<PagingModel<V>> GetPagedResult(F filter, int userId)
        {
            var result = new PagingModel<V>();
            var entities = await _repository.GetAllAsync();
            var entityModels = _mapper.Map<List<E>, List<V>>(entities);

            result.TotalCounts = entities.Count;
            result.Data = entityModels;

            return result;
        }
    }
}
