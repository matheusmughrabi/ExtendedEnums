using ExtendedEnums.Exceptions;
using System.ComponentModel;
using System.Reflection;

namespace ExtendedEnums
{
    public static class EnumsExtensions
    {
        /// <summary>
        /// Returns the DescriptionAttribute of the enum value.
        /// If the value has no description, then value.ToString() is returned
        /// </summary>
        /// <param name="value"></param>
        /// <returns>string</returns>
        public static string ToDescription(this Enum value)
        {
            if (value == null) throw new ExtendedEnumsException("Enum value cannot be null.");

            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            var attribute = (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));

            if (attribute is null)
                return value.ToString();
            else
                return attribute.Description;
        }

        /// <summary>
        /// Get all values defined in the specified enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IEnumerable<TEnum></returns>
        public static IEnumerable<TEnum> GetValues<TEnum>()
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        }

        /// <summary>
        /// Returns true if the value is defined in the enum and false if the value is not defined
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumValue"></param>
        /// <returns>bool</returns>
        public static bool IsDefined<TEnum>(this TEnum enumValue) where TEnum : Enum
        {
            var values = new HashSet<TEnum>((TEnum[])Enum.GetValues(typeof(TEnum)));
            return values.Contains(enumValue);
        }

        /// <summary>
        /// Converts the enum value to an instance of a EnumResult 
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumValue"></param>
        /// <returns>EnumResult</returns>
        public static EnumResult ConvertToEnumResult<TEnum>(this TEnum enumValue) where TEnum : Enum
        {
            var numericValue = Convert.ToInt64(enumValue);

            return new EnumResult(numericValue, enumValue.ToDescription());
        }

        /// <summary>
        /// Returns all values defined in the given enum as an IEnumerable<EnumResult>
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns>IEnumerable<EnumResult></returns>
        public static IEnumerable<EnumResult> GetValuesAsEnumResult<TEnum>() where TEnum : Enum
        {
            var allValues = GetValues<TEnum>();

            var allValuesEnumResult = new List<EnumResult>();
            foreach (var value in allValues)
            {
                allValuesEnumResult.Add(value.ConvertToEnumResult());
            }

            return allValuesEnumResult;
        }
    }
}
