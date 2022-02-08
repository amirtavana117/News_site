using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }
        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "وارد کنید{0} لطفا ")]
        public int GroupId { get; set; }
        [Display(Name = "عنوان خبر")]
        [MaxLength(150)]
        [Required(ErrorMessage = "وارد کنید{0} لطفا ")]
        public string NewsTitle { get; set; }
        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "وارد کنید{0} لطفا ")]
        [DataType(DataType.MultilineText)]
        [MaxLength(350)]
        public string ShortDescribtion { get; set; }
        [Display(Name = "خبر")]
        [Required(ErrorMessage = "وارد کنید{0} لطفا ")]
        [DataType(DataType.MultilineText)]

        public string NewsText { get; set; }
        [Display(Name = "بازدید")]
        public int visited { get; set; }
        [Display(Name = "نام تصویر")]
        public string ImageName { get; set; }
        [Display(Name = "اسلایدر")]
        public bool ShoWInslider { get; set; }
        [Display(Name = "زمان ایجاد")]
        public DateTime CreateDate { get; set; }
        public virtual List<NewsComment> newsComments { get; set; }
        public virtual NewsGroups newsGroups { get; set; }
        public News()
        {

        }
    }

}
