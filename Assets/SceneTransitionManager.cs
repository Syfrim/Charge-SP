using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionManager : MonoBehaviour
{
    public void LoadBattleScene()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene("BattleScene");
        
    }

    
}
