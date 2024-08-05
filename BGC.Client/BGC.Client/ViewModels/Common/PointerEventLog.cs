using System;

namespace BGC.Client.ViewModels.Common
{
    internal class PointerEventLog
    {
        public DateTime Timestamp { get; init; } = DateTime.UtcNow;
        public PointerEventType EventType { get; init; }
        public double X { get; init; }
        public double Y { get; init; }
    }
}
