using AutoMapper;
using System;
using Worklyn_backend.Domain.Enum.Attendance;

namespace Worklyn_backend.Shared.Helpers
{
    public class StringToEnumConverter<TEnum> : ITypeConverter<string, TEnum> where TEnum : struct, Enum
    {
        private readonly TEnum _defaultValue;

        public StringToEnumConverter(TEnum defaultValue)
        {
            _defaultValue = defaultValue;
        }

        public TEnum Convert(string source, TEnum destination, ResolutionContext context)
        {
            if (string.IsNullOrWhiteSpace(source))
                return _defaultValue;

            return Enum.TryParse<TEnum>(source, true, out var parsed)
                ? parsed
                : _defaultValue;
        }
    }
}
