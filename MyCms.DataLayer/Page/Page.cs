using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCms.DataLayer
{
    public class Page
    {
        [Key]
        public int PageID { get; set; }

        [Display(Name = "گروه خبر")]
        public int GroupID { get; set; }

        [Display(Name = "عنوان صفحه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400)]
        public string PageTitle { get; set; }

        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        public string ShortDescription { get; set; }


        [Display(Name = "بازدید")]
        public int PageVisit { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        [Display(Name = "کلمات کلیدی")]
        public string PageTags { get; set; }

        [Display(Name = "نمایش در اسلایدر")]
        public bool ShowInSlider { get; set; }

        [Display(Name = "تاریخ")]
        public DateTime CreateDate { get; set; }

        public virtual PageGroup.PageGroup PageGroup  { get; set; }

    }
}
