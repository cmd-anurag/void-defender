using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManagerScript : MonoBehaviour
{
    public void ReplayGame() {
        SceneManager.LoadScene("GameScene");
    }
    public void ReturnToHome() {
        SceneManager.LoadScene("StartMenu");
    }
    public void QuitGame() {
        Application.Quit();
    }
}
