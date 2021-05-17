using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAttendanceService
    {
        IDataResult<List<Attendance>> GetByCourseId(int id);
        List<Attendance> GetByStudentId(int id);
        IResult Add(Attendance attendance, decimal fee);
    }
}
