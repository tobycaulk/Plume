using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plume.Models.Request.Account.User;
using Plume.Models.Response.Account.User;
using Plume.Models.Mongo;
using AutoMapper;
using Plume.Service.Account.Password;
using static Plume.Models.Response.Account.User.CreateUserAccountResponse;
using Plume.Models.Mongo.DAO;

namespace Plume.Service.Account.User
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IMongoRepository _mongoRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        public UserAccountService(IMongoRepository mongoRepository, IMapper mapper, IPasswordService passwordService)
        {
            _mongoRepository = mongoRepository;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        public AuthenticateUserAccountResponse Authenticate(AuthenticateUserAccountRequest request)
        {
            AuthenticateUserAccountResponse response = new AuthenticateUserAccountResponse();

            string accountId = null;

            UserAccountDAO userAccountDAO = _mongoRepository.FindUserAccountByUsername(request.Username).Result;
            if(userAccountDAO != null)
            {
                if(_passwordService.CheckPassword(request.Password, userAccountDAO.Password))
                {
                    accountId = userAccountDAO.AccountId;        
                }
            }

            response.AccountId = accountId;

            return response;
        }

        public CreateUserAccountResponse Create(CreateUserAccountRequest request)
        {
            CreateUserAccountResponse response = new CreateUserAccountResponse();

            ResponseStatus responseStatus = ResponseStatus.INTERNAL_ERROR;

            if (_mongoRepository.FindUserAccountByUsername(request.Username).Result != null)
            {
                responseStatus = ResponseStatus.ACCOUNT_ALREADY_EXISTS;
            }
            else
            {
                string accountId = System.Guid.NewGuid().ToString();
                UserAccountDAO userAccountDAO = _mapper.Map<UserAccountDAO>(request);
                userAccountDAO.AccountId = accountId;
                userAccountDAO.Password = _passwordService.HashPassword(request.Password);

                _mongoRepository.CreateUserAccount(userAccountDAO);

                if(_mongoRepository.FindUserAccountByAccountId(accountId).Result != null)
                {
                    responseStatus = ResponseStatus.SUCCESS;
                }
                else
                {
                    responseStatus = ResponseStatus.INTERNAL_ERROR;
                }
            }

            response.SetStatus(responseStatus);

            return response;
        }
    }
}
