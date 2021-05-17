using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IDataResult<User> Login(UserLoginDTO user);
        IDataResult<List<User>> GetAll();
        IResult DeleteUser(User user);
    }
}
