using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.Sample01
{
    /// <summary>
    /// 非活性/活性 Viewmodel
    /// </summary>
    public class SampleDisabledViewModel
    {
        /// <summary>
        /// 大
        /// </summary>
        [Display(Name = "大")]
        public string Dai { get; set; }

        /// <summary>
        /// 中
        /// </summary>
        [Display(Name = "中")]
        public string Chu { get; set; }

        /// <summary>
        /// 小
        /// </summary>
        [Display(Name = "小")]
        public string Sho { get; set; }

        /// <summary>
        /// 結果:大
        /// </summary>
        [Display(Name = "結果:大")]
        public string DaiResult { get; set; }

        /// <summary>
        /// 結果:中
        /// </summary>
        [Display(Name = "結果:中")]
        public string ChuResult { get; set; }

        /// <summary>
        /// 結果:小
        /// </summary>
        [Display(Name = "結果:小")]
        public string ShoResult { get; set; }

        /// <summary>
        /// 結果;セット
        /// </summary>
        [Display(Name = "結果:セット")]
        public string SetResult { get; set; }
    }
}
