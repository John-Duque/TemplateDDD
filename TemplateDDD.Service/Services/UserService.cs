using System;
using AutoMapper;
using TemplateDDD.Domain.Entities;
using TemplateDDD.Domain.Interfaces;
using TemplateDDD.Domain.Interfaces.Services;
using TemplateDDD.Domain.Views;

namespace TemplateDDD.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;

        //Todo: Fazer melhorias nesses Metodos
        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserView> Get(Guid id)
        {
            var retorno = await _repository.SelectAsync(id);
            return _mapper.Map<UserEntity, UserView>(retorno);
        }

        public async Task<IEnumerable<UserView>> GetAll()
        {
            var retorno = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UserEntity>, IEnumerable<UserView>>(retorno);
        }

        public async Task<UserView> Post(UserView user)
        {
            var retorno = await _repository.InsertAsync(_mapper.Map<UserView, UserEntity>(user));
            return _mapper.Map<UserEntity, UserView>(retorno);
        }

        public async Task<UserView> Put(UserView user)
        {
            var retorno = await _repository.InsertAsync(_mapper.Map<UserView, UserEntity>(user));
            return _mapper.Map<UserEntity, UserView>(retorno);
        }
    }
}

