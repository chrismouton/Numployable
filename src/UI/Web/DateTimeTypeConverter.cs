using AutoMapper;

namespace Numployable.Application;

public class DateTimeTypeConverter : IValueConverter<DateTimeOffset?, DateTime?>
{
    public DateTime? Convert(DateTimeOffset? source, ResolutionContext context) => source?.LocalDateTime;
}