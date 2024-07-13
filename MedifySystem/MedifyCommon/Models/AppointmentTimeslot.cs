namespace MedifySystem.MedifyCommon.Models;

public class AppointmentTimeslot(DateTime start, TimeSpan duration)
{
    public DateTime Start { get; private set; } = start;
    public TimeSpan Duration { get; private set; } = duration;

    public override string ToString()
    {
        return $"{Start.ToShortTimeString()} - {Start.Add(Duration).ToShortTimeString()}";
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Start, Duration);
    }

    public override bool Equals(object? obj)
    {
        if (obj is AppointmentTimeslot compareSlot)        
            return Start == compareSlot.Start && Duration == compareSlot.Duration;
        
        return false;
    }
}
