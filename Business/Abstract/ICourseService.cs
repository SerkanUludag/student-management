using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICourseService
    {
        IResult Add(Course course);
        IDataResult<List<Course>> GetAll();
        IResult DeleteCourse(Course course);
        IDataResult<List<Course>> GetByTeacherId(int id);
        IDataResult<List<Course>> GetByStudentId(int id);
        IDataResult<Course> GetById(int id);
    }
}
