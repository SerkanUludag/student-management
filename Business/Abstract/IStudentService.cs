using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IStudentService
    {
        IResult Add(Student student);
        IDataResult<Student> GetById(int id);
        IDataResult<List<Student>> GetAll();
        IDataResult<Student> GetByUserId(int userId);
        IResult DeleteStudent(Student student);
        bool AddFee(int studentId, decimal fee);
        IResult PayFee(PaymentDTO paymentInfo);
    }
}
