using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    public GameObject endGamePanel; // Reference to the end-game UI panel

    // Call this function when the game ends
    public void ShowEndGameScreen()
    {
        Time.timeScale = 0; // Pause the game
        endGamePanel.SetActive(true); // Show the end-game panel
    }

    // Restart the game when the "Play Again" button is pressed
    public void RestartGame()
    {
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1; // Ensure time scale is reset
        SceneManager.LoadScene("OpeningScene");
    }
}