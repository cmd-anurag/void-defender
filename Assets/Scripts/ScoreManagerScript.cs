using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ScoreManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreManagerScript Instance;
    [SerializeField]private TextMeshProUGUI textUI;
    [SerializeField]private TextMeshProUGUI highScoreUI;
    private int userScore = 0;
    private const string highscorekey = "HighScore";

    private void Awake() {
        if(Instance==null) Instance = this;
        else {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        userScore = 0;
        UpdateScoreonUI();
        highScoreUI.text = GetHighScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddUnitScore() {
        ++userScore;
        UpdateScoreonUI();


        if(userScore > GetHighScore()) {
            UpdateHighScoreOnUI();
            PlayerPrefs.SetInt(highscorekey, userScore);
            PlayerPrefs.Save();
        }

    }

    public int GetHighScore() {
        return PlayerPrefs.GetInt(highscorekey, 0);
    }

    void UpdateScoreonUI() {
        textUI.text = userScore.ToString();
    }

    

    void UpdateHighScoreOnUI() {
        highScoreUI.text = userScore.ToString();
    }

}
