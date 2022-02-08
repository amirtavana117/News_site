using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class NewsGroups
    {
        [Key]
        public int GroupId { get; set; }
        [Display(Name ="عنوان خبر")]
        [MaxLength(30)]
        [Required(ErrorMessage = "وارد کنید{0} لطفا ")]
        public string GroupTitle { get; set; }
    }
}
