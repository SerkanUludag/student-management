using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class StudentManager : IStudentService
    {
        IStudentDal _studentDal;
        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }


        public IResult Add(Student student)
        {
            student.Fee = 0;
            student.FeePaid = 0;
            try
            {
                _studentDal.Add(student);
            }
            catch (Exception)
            {

                return new Result(false, "Student cannot be added");
            }
            return new Result(true, "Student added");

        }

        public IDataResult<Student> GetById(int id)
        {

            if (_studentDal.Get(s => s.Id == id) != null)
            {
                var result = _studentDal.Get(s => s.Id == id);

                return new SuccessDataResult<Student>(result);
            }
            else
            {
                return new ErrorDataResult<Student>();
            }
        }

        public IDataResult<Student> GetByUserId(int userId)
        {
            Student result;
            try
            {
                result = _studentDal.Get(s => s.UserId == userId);
            }
            catch (Exception)
            {
                return new ErrorDataResult<Student>( "No student found with this user id");
            }
            return new SuccessDataResult<Student>(result);
        }

        public IDataResult<List<Student>> GetAll()
        {
            List<Student> result;
            result = _studentDal.GetAll();
            try
            {
                result = _studentDal.GetAll();
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Student>>(new List<Student> { }, "Error getting all data");
            }
            return new SuccessDataResult<List<Student>>(result);
        }

        public IResult DeleteStudent(Student student)
        {
            try
            {
                _studentDal.Delete(student);
            }
            catch (Exception)
            {

                return new ErrorResult("Student cannot be deleted");
            }
            return new SuccessResult("Student deleted");
        }

        public bool AddFee(int studentId, decimal fee)
        {
            try
            {
                var result = GetById(studentId).Data;
                result.Fee += fee;
                _studentDal.Update(result);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public IResult PayFee(PaymentDTO paymentInfo)
        {
            try
            {
                var result = GetById(paymentInfo.StudentId).Data;
                result.FeePaid += paymentInfo.AmountPaid;
                _studentDal.Update(result);
            }
            catch (Exception)
            {

                return new ErrorResult("Fee cannot be paid");
            }
            return new SuccessResult("Fee paid");
        }
    }
}
