using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    /// <summary>
    /// 在庫テーブル
    /// </summary>
    public class Zaiko
    {
        [Display(Name = "在庫コード")]
        public string ZaikoCode { get; set; }

        [Display(Name = "在庫名")]
        public string ProductName { get; set; }

        [Display(Name = "在庫数")]
        public string ZaikoStock { get; set; }
    }
}
