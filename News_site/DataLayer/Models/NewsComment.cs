using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class NewsComment
    {
        [Key]
        public int CommentId { get; set; }
        [Display(Name = "خبر")]
        [Required(ErrorMessage = "وارد کنید{0} لطفا ")]
        public int NewsId { get; set; }
        [Display(Name = "150")]
        [MaxLength()]
        [Required(ErrorMessage = "وارد کنید{0} لطفا ")]
        public string FullName { get; set; }
        [Display(Name = "ایمیل")]
        [MaxLength(150)]
        [Required(ErrorMessage = "وارد کنید{0} لطفا ")]
        public String Email { get; set; }
        [Display(Name = "نظر")]
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "وارد کنید{0} لطفا ")]
        public string Comment { get; set; }
        [Display(Name = "زمان ایجاد")]
        public DateTime CreateDate { get; set; }
    }
}
