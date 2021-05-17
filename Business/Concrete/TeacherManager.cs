using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        ITeacherDal _teacherDal;
        public TeacherManager(ITeacherDal teacherDal)
        {
            _teacherDal = teacherDal;
        }


        public IResult Add(Teacher teacher)
        {
            try
            {
                _teacherDal.Add(teacher);
            }
            catch (Exception)
            {

                return new Result(false, "Teacher cannot be added");
            }
            return new Result(true, "Teacher added");

        }

        public IDataResult<List<Teacher>> GetAll()
        {
            List<Teacher> result;
            try
            {
                result = _teacherDal.GetAll();
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Teacher>>(new List<Teacher> { }, "Error getting all data");
            }
            return new SuccessDataResult<List<Teacher>>(result);
        }

        public IResult DeleteTeacher(Teacher teacher)
        {
            try
            {
                _teacherDal.Delete(teacher);
            }
            catch (Exception)
            {

                return new ErrorResult("Teacher cannot be deleted");
            }
            return new SuccessResult("Teacher deleted");
        }

        public IDataResult<Teacher> GetById(int id)
        {
            Teacher result;
            try
            {
                result = _teacherDal.Get(t => t.Id == id);
            }
            catch (Exception)
            {
                return new ErrorDataResult<Teacher>( "No teacher with this id");
            }
            return new SuccessDataResult<Teacher>(result);
        }

        public IDataResult<Teacher> GetByUserId(int userId)
        {
            Teacher result;
            try
            {
                result = _teacherDal.Get(t => t.UserId == userId);
            }
            catch (Exception)
            {
                return new ErrorDataResult<Teacher>("No teacher with this id");
            }
            return new SuccessDataResult<Teacher>(result);
        }
    }
}
