using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System_task
{
    public class Instructor : Person
    {
        public string Specialization { get; set; }

        public Instructor(int id, string name, string specialization) : base(id, name)
        {
            Specialization = specialization;
        }

        public override string PrintDetails()
        {
            return $"[Instructor ID: {Id}] Name: {Name}, Specialization: {Specialization}";
        }
    }
}
