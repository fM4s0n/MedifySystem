using MedifySystem.MedifyCommon.Enums;

namespace MedifySystem.MedifyCommon.Dictionaries;

/// <summary>
/// Dictionary for the flpHomeItem back colour
/// </summary>
public class FlpHomeItemBackColourDictionary
{
    private static readonly Dictionary<FlpHomeItemBackColour, string> _flpHomeItemBackColourDictionary = new()
    {
        { FlpHomeItemBackColour.Blue, "#FF3F51B5" },
        { FlpHomeItemBackColour.Green, "#FF4CAF50" },
        { FlpHomeItemBackColour.Red, "#FFF44336" },
        { FlpHomeItemBackColour.Yellow, "#FFFFEB3B" },
        { FlpHomeItemBackColour.Orange, "#FFFF9800" },
        { FlpHomeItemBackColour.Purple, "#FF9C27B0" },
    };

    public static string GetColour(FlpHomeItemBackColour colour)
    {
        return _flpHomeItemBackColourDictionary[colour] ?? "#FFFFFF";
    }
}
