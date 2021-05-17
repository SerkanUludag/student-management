using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Teacher: IEntity
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public string Subject { get; set; }
        public int UserId { get; set; }
    }
}
