using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITeacherService
    {
        IResult Add(Teacher teacher);
        IDataResult<List<Teacher>> GetAll();
        IResult DeleteTeacher(Teacher teacher);
        IDataResult<Teacher> GetByUserId(int userId);
        IDataResult<Teacher> GetById(int id);
    }
}
