using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.Data.Converters
{
    public class EnumToCharConverter<TEnum> : ValueConverter<TEnum, char> where TEnum : struct
    {
        public EnumToCharConverter(ConverterMappingHints mappingHints = null) : base(convertToProviderExpression,
                                                                                     convertFromProviderExpression,
                                                                                     mappingHints)
        {
        }

        static Expression<Func<TEnum, char>> convertToProviderExpression = v => Convert.ToChar(v);
        static Expression<Func<char, TEnum>> convertFromProviderExpression = v => (TEnum)Enum.ToObject(typeof(TEnum), v);

    }
}
