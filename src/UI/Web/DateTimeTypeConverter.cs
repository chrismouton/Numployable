using AutoMapper;

namespace Numployable.UI.Web;

public class DateTimeTypeConverter : IValueConverter<DateTimeOffset?, DateTime?>
{
  public DateTime? Convert(DateTimeOffset? source, ResolutionContext context)
  {
    return source?.LocalDateTime;
  }
}
