using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour, IDataPersistence
{
#pragma warning disable 0649
    [SerializeField] private Button[] _fpsButtons;
    [SerializeField] private Image _musicToggleImage;
    [SerializeField] private Image _sfxToggleImage;
    [SerializeField] private Image _hapticSliderImage;
    [SerializeField] private Sprite _onToggleSprite;
    [SerializeField] private Sprite _offToggleSprite;
#pragma warning restore 0649

    private Button _currentFpsButton;

    public void OnStart()
    {
        for (int i = 0; i < _fpsButtons.Length; i++)
        {
            if (!_fpsButtons[i].interactable)
            {
                _fpsButtons[i].interactable = true;
                continue;
            }
        }

        _currentFpsButton = _fpsButtons[GameCurrentData.FpsIndex];
        _currentFpsButton.interactable = false;
        Application.targetFrameRate = 60 + (GameCurrentData.FpsIndex * 30);

        SetMusicText();
        SetSfxText();
        SetHapticText();

        AudioManager.Instance.SetAudio();
    }

    // via link inspector
    public void ChooseFPS(int fpsIndex)
    {
        Application.targetFrameRate = 30 + (fpsIndex * 30);

        GameCurrentData.FpsIndex = fpsIndex;
        for (int i = 0; i < _fpsButtons.Length; i++)
        {
            if (!_fpsButtons[i].interactable)
            {
                _fpsButtons[i].interactable = true;
                continue;
            }
        }

        _currentFpsButton.interactable = true;
        _fpsButtons[fpsIndex].interactable = false;
        _currentFpsButton = _fpsButtons[fpsIndex];
    }

    // via link inspector
    public void MusicOnOff()
    {
        GameCurrentData.MusicOnOff *= -1;
        SetMusicText();
    }

    // via link inspector
    public void SfxOnOff()
    {
        GameCurrentData.SfxOnOff *= -1;
        SetSfxText();
    }

    // via link inspector
    public void HapticOnOff()
    {
        GameCurrentData.HapticOnOff *= -1;
        SetHapticText();
    }

    private void SetMusicText()
    {
        if (GameCurrentData.MusicOnOff == 1)
            _musicToggleImage.sprite = _onToggleSprite;
        else if (GameCurrentData.MusicOnOff == -1)
            _musicToggleImage.sprite = _offToggleSprite;
    }

    private void SetSfxText()
    {
        if (GameCurrentData.SfxOnOff == 1)
            _sfxToggleImage.sprite = _onToggleSprite;
        else if (GameCurrentData.SfxOnOff == -1)
            _sfxToggleImage.sprite = _offToggleSprite;
    }

    private void SetHapticText()
    {
        if (GameCurrentData.HapticOnOff == 1)
            _hapticSliderImage.sprite = _onToggleSprite;
        else if (GameCurrentData.HapticOnOff == -1)
            _hapticSliderImage.sprite = _offToggleSprite;
    }

    public void LoadGameData(GameData gameData)
    {
        GameCurrentData.FpsIndex = gameData.fpsIndex;
        GameCurrentData.MusicOnOff = gameData.musicOnOff;
        GameCurrentData.SfxOnOff = gameData.sfxOnOff;
        GameCurrentData.HapticOnOff = gameData.hapticOnOff;
    }

    public void SaveGameData(ref GameData gameData)
    {
        gameData.fpsIndex = GameCurrentData.FpsIndex;
        gameData.musicOnOff = GameCurrentData.MusicOnOff;
        gameData.sfxOnOff = GameCurrentData.SfxOnOff;
        gameData.hapticOnOff = GameCurrentData.HapticOnOff;
    }
}
