namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MVC5Course.Models.DataTypes;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Stock < 10 && this.Price > 900)
            {
                yield return new ValidationResult(
                    "Stock < 10 && Price > 900 是錯誤的資料設定!", 
                    new string[] { "Stock", "Price" });
            }
        }
    }

    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
        
        [Required(ErrorMessage = "請輸入產品名稱")]
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
        [身分證字號(ErrorMessage = "必須包含 Will")]
        public string ProductName { get; set; }

        [Required]
        [Range(0, 999, ErrorMessage = "產品金額必須介於 0~999 以內")]
        public Nullable<decimal> Price { get; set; }

        [Required]
        public Nullable<bool> Active { get; set; }

        [Required]
        public Nullable<decimal> Stock { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
