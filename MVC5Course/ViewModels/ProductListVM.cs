namespace MVC5Course.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ProductListVM
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "請輸入產品名稱")]
        public string ProductName { get; set; }

        [Required]
        [Range(0, 999, ErrorMessage = "產品金額只能介於 0 ~ 999")]
        public Nullable<decimal> Price { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:#}")]
        public Nullable<decimal> Stock { get; set; }
    }
}