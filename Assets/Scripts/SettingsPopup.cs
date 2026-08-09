using UnityEngine;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] GameObject settingsPopup;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource endSoundSource;

    bool isGamePaused = false;
    bool isAudioPlaying = true;
    bool isSFXPlaying = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isGamePaused)
            {
                Close();
            }
            else {
                Open();
            }
        
        }
    }
    void Open() {
        settingsPopup.SetActive(true);
        SetGameActive(false);
        isGamePaused = true;
    }

    public void Close() {
        settingsPopup.SetActive(false);
        SetGameActive(true);
        isGamePaused = false;
    }
    public void SetGameActive(bool active) {
        if (active) { 
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            
            
        }
        else {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            
           
        }
    }
    public void AudioControl() {
        if (musicSource != null) { 
            isAudioPlaying = !isAudioPlaying;
            musicSource.mute = !isAudioPlaying;
        }
        if (endSoundSource != null) {
            endSoundSource.mute = !isAudioPlaying;
        }

    }
    public void SFXControl() {
        if (sfxSource != null) { 
            isSFXPlaying = !isSFXPlaying;
            sfxSource.mute = !isSFXPlaying;
        }
    }
}
