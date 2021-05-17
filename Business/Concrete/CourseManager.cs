using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CourseManager : ICourseService
    {
        ICourseDal _courseDal;
        IAttendanceService _attendanceService;
        public CourseManager(ICourseDal courseDal, IAttendanceService attendanceService)
        {
            _courseDal = courseDal;
            _attendanceService = attendanceService;
        }


        public IResult Add(Course course)
        {
            try
            {
                _courseDal.Add(course);
            }
            catch (Exception)
            {

                return new Result(false, "Course cannot be added");
            }
            return new Result(true, "Course added");

        }

        public IDataResult<List<Course>> GetAll()
        {
            List<Course> result;
            
            try
            {
                result = _courseDal.GetAll();
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Course>>(new List<Course> { }, "Error getting all data");
            }
            return new SuccessDataResult<List<Course>>(result);
        }

        public IResult DeleteCourse(Course course)
        {
            try
            {
                _courseDal.Delete(course);
            }
            catch (Exception)
            {

                return new ErrorResult("Course cannot be deleted");
            }
            return new SuccessResult("Course deleted");
        }

        public IDataResult<List<Course>> GetByTeacherId(int id)
        {
            List<Course> result;
            try
            {
                result = _courseDal.GetAll(c => c.TeacherId == id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Course>>( "Error getting data");
            }
            return new SuccessDataResult<List<Course>>(result);
        }

        public IDataResult<List<Course>> GetByStudentId(int id)
        {
            List<Attendance> attendances;
            try
            {
                attendances = _attendanceService.GetByStudentId(id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Course>>();
            }
            List<Course> result = new List<Course>();
            for(int i=0; i<attendances.Count; i++)
            {
                result.Add(_courseDal.Get(c => c.Id == attendances[i].CourseId));
            }
            return new SuccessDataResult<List<Course>>(result);
        }

        public IDataResult<Course> GetById(int id)
        {
            if(_courseDal.Get(c => c.Id == id) is null)
            {
                return new ErrorDataResult<Course>("No course found with this is");
            }
            else
            {
                return new SuccessDataResult<Course>(_courseDal.Get(c => c.Id == id));
            }
        }
    }
}
