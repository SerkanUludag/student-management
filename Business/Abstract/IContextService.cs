using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IContextService
    {
        IResult Add(Context context);
        IDataResult<Context> GetById(int id);
        IDataResult<List<Context>> GetByCourseId(int id);
    }
}
