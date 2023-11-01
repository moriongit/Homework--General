using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Indexer_task_2.Models
{
    public class Gallery
    {
        public string Name { get; set; }
        public Car[] Cars { get; set; }

        public Car this[int index]
        {
            get
            {
                if (index >= 0 && index < Cars.Length)
                {
                    return Cars[index];
                }
                return null; 
            }
            set
            {
                if (index >= 0 && index < Cars.Length)
                {
                    Cars[index] = value;
                }
            }
        }

        public bool this[string carName]
        {
            get
            {
                foreach (Car car in Cars)
                {
                    if (car.Name == carName)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
