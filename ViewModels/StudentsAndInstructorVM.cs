using KimiNoGakko.Models;
using System.Collections.Generic;

namespace KimiNoGakko.ViewModels
{
    public class StudentsAndInstructorVM
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Instructor> Instructors { get; set; }
    }
}
