using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
        public List<Cart> Carts { get; set; }
        public LectureAnswer LectureAnswer { get; set; }
        public List<StudentLecture> StudentLectures { get; set; }

    }
}
