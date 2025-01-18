using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningScreenManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider volumeSlider;
    public AudioSource gameAudio;
    public AudioSource buttonSound;

    private void Start()
    {
        // Initialize volume
        volumeSlider.value = AudioListener.volume;
        volumeSlider.onValueChanged.AddListener(SetVolume);
        
    }

    public void PlayGame()
    {   
        
        PlayButtonSound(); // Play button sound
        SceneManager.LoadScene("TutorialScene"); // Load the tutorial scene
    }

    public void LoadTutorialScene()
    {
        PlayButtonSound(); // Play button sound
        Debug.Log("Play button clicked. Loading Tutorial Scene...");
        SceneManager.LoadScene("TutorialScene");
    }

    public void OpenSettings()
    {   
        
        PlayButtonSound(); // Play button sound
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {   
        PlayButtonSound(); // Play button sound
        settingsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        PlayButtonSound(); // Play button sound
        Debug.Log("Exit button clicked. Exiting game...");
        Application.Quit();
    }

    private void PlayButtonSound()
    {
        if (buttonSound != null)
        {   
            
            buttonSound.Play(); // Play the button click sound
        }
    }

    private void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
}
