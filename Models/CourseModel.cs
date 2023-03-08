using System.ComponentModel.DataAnnotations;

namespace BigSchool.Models {
    public class CourseModel {
        
        public int Id { get; set; }
        public AppUser Lecturer { get; set; }
        [Required]
        public string LecturerId { get; set; }
        [Required]
        [StringLength(255)]
        public string Place { get; set; }
        public DateTime Datetime { get; set; }
        public CategoryModel Category { get; set; }
        [Required]
        public byte CategoryId { get; set; }
    }
   
}