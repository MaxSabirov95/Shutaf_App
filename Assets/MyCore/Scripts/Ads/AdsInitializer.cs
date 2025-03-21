using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    public static AdsInitializer Instance;
    private string _androidGameId;
    private string _iOSGameId;
    private bool _testMode = true;
    private string _gameId;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _androidGameId = ProjectInfoSettings.GetAndroidAdsKey();
        _iOSGameId = ProjectInfoSettings.GetIosAdsKey();
        _testMode = ProjectInfoSettings.GetIsAdsTest();
    }

    public void InitializeAds()
    {
#if UNITY_IOS
            _gameId = _iOSGameId;
#elif UNITY_ANDROID
        _gameId = _androidGameId;
#elif UNITY_EDITOR
            _gameId = _androidGameId; //Only for testing the functionality in the Editor
#endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);
        }
    }

    public void OnInitializationComplete()
    {
        //Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    private void OnDestroy()
    {
        Instance = this;
    }
}