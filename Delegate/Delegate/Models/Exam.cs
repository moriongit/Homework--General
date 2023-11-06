using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Models
{
    class Exam
    {
        public string Student { get; set; }
        public int Point { get; set; }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public TimeSpan Duration => EndDate - StartDate;
    }
}
