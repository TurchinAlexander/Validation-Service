using System;
using Validation_Service.Attributes;

namespace UnitTestProject.Entitites
{
    public class ValidationServiceTestEntity
    {
        [Range(0, 9)]
        public int Digit { get; private set; }

        [Range(-5, -1)]
        public int NegativeInteger { get; set; }

        [MinLength(1)]
        public string MoreOneCharString { get; set; }

        [Required]
        public object RequiredObject { get; set; }

        [Required(AllowEmptyString = false)]
        public string NotEmptyString { get; set; }

        public ValidationServiceTestEntity(int digit, int negativeInteger,
            string moreOneCharString, object requiredObject,
            string notEmptyString)
        {
            this.Digit = digit;
            this.NegativeInteger = negativeInteger;
            this.MoreOneCharString = moreOneCharString;
            this.RequiredObject = requiredObject;
            this.NotEmptyString = notEmptyString;
        }
    }
}
