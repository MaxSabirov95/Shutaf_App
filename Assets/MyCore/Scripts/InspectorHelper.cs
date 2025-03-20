#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System;
using System.Collections;
using System.IO;

public class InspectorHelper : Editor
{
    [MenuItem("Main Core/Play From Start")]
    [System.Obsolete]
    public static void EnterStartScene()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
            return;
        }

        EditorApplication.OpenScene("Assets/MyCore/Scenes/Start.unity");
        EditorApplication.isPlaying = true;
    }

    [MenuItem("Main Core/Take Screenshot")]
    [System.Obsolete]
    public static void CaptureScreenshot()
    {
        if (!EditorApplication.isPlaying) EditorApplication.isPlaying = false;
        ScreenCapture.CaptureScreenshot("Assets/Screenshot_" + Screen.width + "x" + Screen.height + "_" + DateTime.Now.ToString("yyyy-mm-dd-hh-mm-ss") + ".png");
        AssetDatabase.Refresh();
    }
}
#endif