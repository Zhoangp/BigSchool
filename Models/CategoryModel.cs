using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigSchool.Models {

    public class CategoryModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string? Name { get; set; }
     
    }
    
    
}