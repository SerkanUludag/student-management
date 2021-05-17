using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ContextManager:IContextService
    {
        IContextDal _contextDal;
        public ContextManager(IContextDal contextDal)
        {
            _contextDal = contextDal;
        }
        public IResult Add(Context context)
        {
            try
            {
                _contextDal.Add(context);
            }
            catch (Exception)
            {

                return new Result(false, "Context cannot be added");
            }
            return new Result(true, "Context added");

        }

        public IDataResult<Context> GetById(int id)
        {
            Context result;
            try
            {
                result = _contextDal.Get(c => c.Id == id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Context>("Cannot get content");
            }
            return new SuccessDataResult<Context>(result);
        }

        public IDataResult<List<Context>> GetByCourseId(int id)
        {
            List<Context> result;
            result = _contextDal.GetAll(c => c.CourseId == id);
            try
            {
                result = _contextDal.GetAll(c => c.CourseId == id);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Context>>("Cannot get course contents");
            }
            return new SuccessDataResult<List<Context>>(result);
        }
    }
}
