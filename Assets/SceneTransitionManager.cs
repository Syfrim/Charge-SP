using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public void LoadBattleScene()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
