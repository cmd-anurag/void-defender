using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ScoreManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreManagerScript Instance;
    public TextMeshProUGUI textUI;
    private int userScore = 0;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddUnitScore() {
        ++userScore;
        UpdateScoreonUI();
    }

    void UpdateScoreonUI() {
        textUI.text = userScore.ToString();
    }

}
