using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public IResult Add(User user)
        {
            try
            {
                _userDal.Add(user);
            }
            catch (Exception)
            {

                return new ErrorResult("User cannot be added");
            }
            return new SuccessResult("User added");

        }

        public IDataResult<User> Login(UserLoginDTO user)
        {

            if (_userDal.Get(u => u.Username == user.Username) is null)
            {
                return new ErrorDataResult<User>("User not found");
            }
            else
            {
                var userToLogin = _userDal.Get(u => u.Username == user.Username);
                if (userToLogin.Password == user.Password)
                {
                    return new SuccessDataResult<User>(userToLogin, "Login successfull");
                }
                else
                {
                    return new ErrorDataResult<User>("Password incorrect");
                }
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            List<User> result;
            try
            {
                result = _userDal.GetAll();
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<User>>(new List<User> { }, "Error getting all data");
            }
            return new SuccessDataResult<List<User>>(result);


        }

        public IResult DeleteUser(User user)
        {
            try
            {
                _userDal.Delete(user);
            }
            catch (Exception)
            {

                return new ErrorResult("User cannot be deleted");
            }
            return new SuccessResult("User deleted");
        }
    }
}
