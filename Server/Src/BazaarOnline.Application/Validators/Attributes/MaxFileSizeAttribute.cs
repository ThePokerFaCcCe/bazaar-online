using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BazaarOnline.Application.Validators.Attributes
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly long _maxFileSize;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxFileSize">size in kilobytes</param>
        public MaxFileSizeAttribute(long maxFileSize)
        {
            _maxFileSize = maxFileSize * 1024;
        }

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            string mb = (_maxFileSize / 1024).ToString();
            return $"حجم مجاز برای فایل {mb} کیلو بایت می باشد.";
        }
    }
}
