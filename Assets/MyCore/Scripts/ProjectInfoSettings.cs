#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class ProjectInfoSettings : EditorWindow
{
    private static string _companyName = "LuckyKevin";
    private static string _startDataName = "ProjectInfoSettings_";

    private static string _productName;

    private static int _projectID;

    private static string _projectPackageName;
    private static string _projectVersion;
    private static int _projectBuild;

    private static bool _isAdsTest;
    private static string _androidAdsKey;
    private static string _iosAdsKey;

    [MenuItem("Main Core/Project Info Settings")]
    public static void ShowWindow()
    {
        GetWindow<ProjectInfoSettings>("Project Info Settings");
    }

    private void OnEnable()
    {
        _productName = PlayerPrefsMananger.LoadString(_startDataName + "ProductName");
        _projectID = PlayerPrefsMananger.LoadInt(_startDataName + "ProjectID");
        _projectPackageName = PlayerPrefsMananger.LoadString(_startDataName + "ProjectPackageName");
        _projectVersion = PlayerPrefsMananger.LoadString(_startDataName + "ProjectVersion");
        _projectBuild = PlayerPrefsMananger.LoadInt(_startDataName + "ProjectBuild");
        _isAdsTest = PlayerPrefsMananger.LoadBool(_startDataName + "IsAdsTest");
        _androidAdsKey = PlayerPrefsMananger.LoadString(_startDataName + "AndroidAdsKey");
        _iosAdsKey = PlayerPrefsMananger.LoadString(_startDataName + "IosAdsKey");
    }

    private void OnGUI()
    {
        GUILayout.Label("Project Info Settings", EditorStyles.boldLabel);

        _productName = EditorGUILayout.TextField("Product Name", _productName);
        _projectID = EditorGUILayout.IntField("ID", _projectID);

        GUILayout.Space(20);

        _projectPackageName = EditorGUILayout.TextField("Package Name", _projectPackageName);
        _projectVersion = EditorGUILayout.TextField("Version", _projectVersion);
        _projectBuild = EditorGUILayout.IntField("Build", _projectBuild);

        GUILayout.Space(20);

        _isAdsTest = EditorGUILayout.Toggle("Is Ads Test", _isAdsTest);
        _androidAdsKey = EditorGUILayout.TextField("Android Ads Key", _androidAdsKey);
        _iosAdsKey = EditorGUILayout.TextField("iOS Ads Key", _iosAdsKey);

        GUILayout.Space(20);

        if (GUILayout.Button("Update Project Data"))
        {
            UpdateData();
        }

        if (GUI.changed)
        {
            PlayerPrefsMananger.SaveString(_startDataName + "ProductName", _productName);
            PlayerPrefsMananger.SaveInt(_startDataName + "ProjectID", _projectID);
            PlayerPrefsMananger.SaveString(_startDataName + "ProjectPackageName", _projectPackageName);
            PlayerPrefsMananger.SaveString(_startDataName + "ProjectVersion", _projectVersion);
            PlayerPrefsMananger.SaveInt(_startDataName + "ProjectBuild", _projectBuild);
            PlayerPrefsMananger.SaveBool(_startDataName + "IsAdsTest", _isAdsTest);
            PlayerPrefsMananger.SaveString(_startDataName + "AndroidAdsKey", _androidAdsKey);
            PlayerPrefsMananger.SaveString(_startDataName + "IosAdsKey", _iosAdsKey);
            PlayerPrefs.Save();
        }
    }

    private static void UpdateData()
    {
        if (_projectPackageName == "")
        {
            if (_productName == "")
            {
                Debug.LogError("Product Name Is Null");
                return;
            }

            _projectPackageName = "com." + _companyName + "." + _productName;
        }

        PlayerSettings.productName = _productName;
        PlayerSettings.companyName = _companyName;

        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, _projectPackageName);
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS, _projectPackageName);

        PlayerSettings.bundleVersion = _projectVersion;
        PlayerSettings.Android.bundleVersionCode = _projectBuild;

        PlayerSettings.iOS.buildNumber = _projectBuild.ToString();
    }

    public static int GetProjectID()
    {
        return _projectID;
    }

    public static bool GetIsAdsTest()
    {
        return _isAdsTest;
    }

    public static string GetAndroidAdsKey()
    {
        return _androidAdsKey;
    }

    public static string GetIosAdsKey()
    {
        return _iosAdsKey;
    }
}
#endif