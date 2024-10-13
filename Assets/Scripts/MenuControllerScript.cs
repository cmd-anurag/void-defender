using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame() {
        SceneManager.LoadScene("GameScene");
    }
    public void QuitGame() {
        Application.Quit();
    }
}
