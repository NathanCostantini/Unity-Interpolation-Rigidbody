using System.Text.RegularExpressions;
using UnityEngine;

public static class Utils
{
    public static bool IsValidPath(string folderPath)
    {
        return !new Regex("[:*?\"<>|]").IsMatch(folderPath);
    }

    public static float Round(float value, uint numDecimals)
    {
        float multiplier = Mathf.Pow(10, numDecimals);
        return Mathf.Round(value * multiplier) / multiplier;
    }

    public static float Angle360To180(float angle)
    {
        return (angle + 540) % 360 - 180;
    }

    public static float Angle180To360(float angle)
    {
        return (angle + 360) % 360;
    }
}
