using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace AwesomeBackend.Common.Validation
{
    public class NotFutureDateAttribute : ValidationAttribute
    {
        public DateTime MinimumDate { get; set; }

        public NotFutureDateAttribute()
        {
        }

        public NotFutureDateAttribute(string minimumDate)
        {
            if (DateTime.TryParseExact(minimumDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
            {
                MinimumDate = date;
            }
        }

        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date > MinimumDate && date < DateTime.UtcNow;
            }

            return false;
        }
    }
}
