using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.Events;
//using UnityEditor.Events;

public class RewardedAdsButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
#pragma warning disable 0649
    [SerializeField] private Button _showAdButton;
    [SerializeField] private string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] private string _iOSAdUnitId = "Rewarded_iOS";

    [SerializeField] private UnityEvent _rewardAction;
#pragma warning restore 0649
    string _adUnitId = null; // This will remain null for unsupported platforms

    // Call this public method when you want to get an ad ready to show.
    public void LoadAd()
    {
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif

        //Debug.Log(_adUnitId);
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        //Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        //Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
            // Configure the button to call the ShowAd() method when clicked:
            //if (MainMenuManager.Instance)
            //    UnityEventTools.RemovePersistentListener(_showAdButton.onClick, MainMenuManager.Instance.ShowAdErrorMassage);
            //else if (GamePlayManager.Instance)
            //    UnityEventTools.RemovePersistentListener(_showAdButton.onClick, GamePlayManager.Instance.ShowAdErrorMassage);
            _showAdButton.onClick.AddListener(ShowAd);
            // Enable the button for users to click:
            _showAdButton.interactable = true;
        }
    }

    // Implement a method to execute when the user clicks the button:
    public void ShowAd()
    {
        _showAdButton.interactable = false;

        // Then show the ad:
        Advertisement.Show(_adUnitId, this);
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            //Debug.Log("Unity Ads Rewarded Ad Completed");
            _rewardAction?.Invoke();
            Utils.DebugLog("You Rewarded");
        }
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Utils.DebugLog($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Utils.DebugLog($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");

        //if (MainMenuManager.Instance)
        //    MainMenuManager.Instance.ShowAdFailurObject();
        //else if (GamePlayManager.Instance)
        //    GamePlayManager.Instance.ShowAdFailurObject();

        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        //_showAdButton.onClick.RemoveAllListeners();
    }
}