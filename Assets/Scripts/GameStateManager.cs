using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{

    // EVENT SUBSCRIPTIONS
    private void OnEnable() {
        SpaceshipControllerScript.OnSpaceShipDeath += LoadGameOverScene;
    }

    private void OnDisable() {
        SpaceshipControllerScript.OnSpaceShipDeath -= LoadGameOverScene;
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

    public void LoadGameOverScene(Transform pos) {
        StartCoroutine(LoadGameOverAfterDelay(2f));
    }

    private IEnumerator LoadGameOverAfterDelay(float delay=2f) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOver");
    }

}
