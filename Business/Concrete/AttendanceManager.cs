using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AttendanceManager : IAttendanceService
    {
        IAttendanceDal _attendanceDal;
        IStudentService _studentService;
        public AttendanceManager(IAttendanceDal attendanceDal, IStudentService studentService)
        {
            _attendanceDal = attendanceDal;
            _studentService = studentService;
        }

        public IResult Add(Attendance attendance, decimal fee)
        {
            if (checkIsEnrolledBefore(attendance))
            {
                try
                {
                    _attendanceDal.Add(attendance);
                    if(_studentService.AddFee(attendance.StudentId, fee))
                    {
                        return new SuccessResult("Enrolled course");
                    }
                    else
                    {
                        return new ErrorResult("Fee cannot be added");
                    }
                }
                catch (Exception)
                {

                    return new ErrorResult("Error occurred while enrolling");
                }
                
            }
            else
            {
                return new ErrorResult("Student already enrolled this course");
            }         
        }

        public IDataResult<List<Attendance>> GetByCourseId(int id)
        {
            if(_attendanceDal.GetAll(a => a.CourseId == id).Count == 0)
            {
                return new ErrorDataResult<List<Attendance>>("No attendance exists on this course");
            }
            else
            {
                return new SuccessDataResult<List<Attendance>>(_attendanceDal.GetAll(a => a.CourseId == id));
            }
        }

        public List<Attendance> GetByStudentId(int id)
        {
            return _attendanceDal.GetAll(a => a.StudentId == id);
        }

        private bool checkIsEnrolledBefore(Attendance attendance)
        {
            if(_attendanceDal.GetAll(a => a.CourseId == attendance.CourseId && a.StudentId == attendance.StudentId).Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
