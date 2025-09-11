namespace Worklyn_backend.Domain.ValueObjects.Date
{
    public class DateRangeVO
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        private DateRangeVO() { }
        public DateRangeVO(DateTime start, DateTime end)
        {
            if (end < start) throw new ArgumentException("End date cannot be before start date");
            Start = start;
            End = end;
        }

        public int TotalDays => (End - Start).Days + 1;

    }
}
