using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Student: IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string College { get; set; }
        public decimal? Fee { get; set; }
        public decimal? FeePaid { get; set; }
        public string Year { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
