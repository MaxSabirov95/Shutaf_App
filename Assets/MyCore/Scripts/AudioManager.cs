using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

#pragma warning disable 0649
    [Header("Background Music")]
    [SerializeField] private AudioClip _backgroundAudioClip;
    [SerializeField] private AudioSource _backgroundAudioSource;
    [SerializeField] private float _backgroundVolume;

    [Header("SFX Sounds")]
    [SerializeField] private AudioSource _sfxSoundsAudioSource;
#pragma warning restore 0649

    private bool _isMusicOff;
    private bool _isSfxOff;

    private void Awake()
    {
        Instance = this;
    }

    private void PlayBackGroundMusic(AudioClip audioClip, float volume = 1f)
    {
        if (_isMusicOff) 
        {
            _backgroundAudioSource.Stop();
            return;
        } 

        _backgroundAudioSource.loop = true;
        _backgroundAudioSource.volume = volume;
        _backgroundAudioSource.clip = audioClip;
        _backgroundAudioSource.Play();
    }

    public void PlaySFXSound(AudioClip audioClip, float volume = 1f, bool forcePlay = false)
    {
        if (!forcePlay)
        {
            if (_isSfxOff) return;
        }

        _sfxSoundsAudioSource.volume = volume;
        _sfxSoundsAudioSource.PlayOneShot(audioClip);
    }

    public void StopSFXSound()
    {
        _sfxSoundsAudioSource.volume = 0;
    }

    public void FadeOutFadeOutBGMusic()
    {
        StartCoroutine(nameof(FadeOutBGMusicCoroutine));
    }

    private IEnumerator FadeOutBGMusicCoroutine()
    {
        float volume = _backgroundAudioSource.volume;
        while (volume > 0)
        {
            volume -= Time.deltaTime;
            _backgroundAudioSource.volume = volume;
            yield return null;
        }
    }

    public void SetAudio()
    {
        if (GameCurrentData.MusicOnOff == -1)
            _isMusicOff = true;
        else
            _isMusicOff = false;

        if (GameCurrentData.SfxOnOff == -1)
            _isSfxOff = true;
        else
            _isSfxOff = false;

        if (_backgroundAudioClip != null)
        {
            PlayBackGroundMusic(_backgroundAudioClip, _backgroundVolume);
        }
    }

    public void PlayAudioWithDelay(float delayTime)
    {
        StartCoroutine(PlayDelaySound(delayTime));
    }

    IEnumerator PlayDelaySound(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SetAudio();
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}