using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
