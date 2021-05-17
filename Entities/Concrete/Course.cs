using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Course: IEntity
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public decimal CourseFee { get; set; }
        public string Duration { get; set; }
        public int TeacherId { get; set; }
    }
}
