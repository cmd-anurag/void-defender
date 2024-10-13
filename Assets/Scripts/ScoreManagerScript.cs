using TMPro;
using UnityEngine;
public class ScoreManagerScript : MonoBehaviour
{
    // UI ELEMENTS
    [SerializeField]private TextMeshProUGUI textUI;
    [SerializeField]private TextMeshProUGUI highScoreUI;

    // PROPERTIES of GameObject
    private int userScore = 0;
    private const string highscorekey = "HighScore";

    // EVENT Subscriptions
    private void OnEnable() {
        // This event is fired when an enemy dies
        EnemyScript.OnEnemyDeath += AddUnitScore;
    }
    private void OnDisable() {
        EnemyScript.OnEnemyDeath -= AddUnitScore;
    }
   
    void Start()
    {
        userScore = 0;
        UpdateScoreonUI();
        highScoreUI.text = GetHighScore().ToString();
    }

    private void AddUnitScore(int score, Transform position) {
        userScore += score;
        UpdateScoreonUI();

        if(userScore > GetHighScore()) {
            UpdateHighScoreOnUI();
            PlayerPrefs.SetInt(highscorekey, userScore);
            PlayerPrefs.Save();
        }

    }

    private int GetHighScore() {
        return PlayerPrefs.GetInt(highscorekey, 0);
    }

    private void UpdateScoreonUI() {
        textUI.text = userScore.ToString();
    }

    private void UpdateHighScoreOnUI() {
        highScoreUI.text = userScore.ToString();
    }

}
