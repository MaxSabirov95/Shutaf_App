using UnityEngine;

public class AudioPlay : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private AudioClip _audio;
    [SerializeField] private float _volume;

    [SerializeField] private bool _forcePlay;
#pragma warning restore 0649

#if UNITY_EDITOR
    private void Start()
    {
        if (_audio == null)
            Debug.LogError(gameObject.name + " is Audio Null", gameObject);
    }
#endif

    // via link inspector
    public void PlayAudio()
    {
        if (_audio == null)
        {
            Debug.LogError(gameObject.name + " AudioClip Is Null", gameObject);
            return;
        }

        if(AudioManager.Instance)
            AudioManager.Instance.PlaySFXSound(_audio, _volume, _forcePlay);
    }

    public void StopAudio()
    {
        AudioManager.Instance.StopSFXSound();
    }
}