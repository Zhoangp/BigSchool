using System.ComponentModel.DataAnnotations;
using BigSchool.Models;

namespace BigSchool.ViewModels
{
    public class CourseViewModel
    {
        [Required]
        public string Place { get; set; }
        [Required]
        [FutureDate]
        public string Date { get; set; }
        [Required]
        [ValidTime]
        public string Time { get; set; }
        public int Category { get; set; }

        public IEnumerable<CategoryModel>? Categories { get; set; }
        public DateTime GetDateTime()
        {

            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }



    }
}