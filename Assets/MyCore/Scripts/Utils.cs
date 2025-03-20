using UnityEngine;

public class Utils : MonoBehaviour
{
    private static readonly float _longPortraitScreen = 0.5f;
    private static readonly float _longLandscapeScreen = 2f;

    private static readonly float _normalPortraitScreen = 0.625f;
    private static readonly float _normalLandscapeScreen = 1.6f;

    private static bool ShowDebugLog = true;

    public static float GetScreenAspectRatio()
    {
        return (float)Screen.width / Screen.height;
    }

    public static bool IsPortrait()
    {
        if (Screen.width > Screen.height)
            return false;
        else
            return true;
    }

    public static bool IsLongScreen()
    {
        if (IsPortrait())
            return GetScreenAspectRatio() <= _longPortraitScreen;
        else
            return GetScreenAspectRatio() >= _longLandscapeScreen;
    }

    public static bool IsNormalScreen()
    {
        if (IsPortrait())
            return GetScreenAspectRatio() <= _normalPortraitScreen;
        else
            return GetScreenAspectRatio() >= _normalLandscapeScreen;
    }

    public static string SetStringNumber(int number)
    {
        if (number < 10000)
        {
            if (number < 1000)
                return number.ToString();
            else
                return (number / 1000f).ToString("f3");
        }
        else
        {
            return (number / 1000f).ToString("f1") + "K";
        }
    }

    public static void DebugLog(string text)
    {
#if UNITY_EDITOR
        if (!ShowDebugLog) return;
        Debug.Log(text);
#endif
    }
}