using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighestScore : MonoBehaviour
{
    const int NUM_HIGH_SCORES = 5;
    const string NAME_KEY = "player";
    const string SCORE_KEY = "score";

    [SerializeField] string playerName;
    [SerializeField] int playerScore;

    [SerializeField] Text[] nameTexts;
    [SerializeField] Text[] scoreTexts;

    // Start is called before the first frame update
    void Start()
    {

        playerName = PersistentData.Instance.GetName();
        playerScore = PersistentData.Instance.GetScore();

        SaveHighScores();

        ShowHighScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SaveHighScores() {
        for (int i = 1; i <= NUM_HIGH_SCORES; i++) {
            string currentScoreKey = SCORE_KEY + i;
            string currentPlayerKey = NAME_KEY + i;

            if (PlayerPrefs.HasKey(currentScoreKey)) {
            int currentScore = PlayerPrefs.GetInt(currentScoreKey);
            if (playerScore >= currentScore) {
                string tempName = PlayerPrefs.GetString(currentPlayerKey);
                int tempScore = currentScore;

                PlayerPrefs.SetString(currentPlayerKey, playerName);
                PlayerPrefs.SetInt(currentScoreKey, playerScore);

                playerName = tempName;
                playerScore = tempScore;
            }

        } else {
            PlayerPrefs.SetString(currentPlayerKey, playerName);
            PlayerPrefs.SetInt(currentScoreKey, playerScore);
            return;
        }
        }
     
    }

    void ShowHighScores() {
        for (int i = 0; i < NUM_HIGH_SCORES; i++) {    
            nameTexts[i].text = PlayerPrefs.GetString(NAME_KEY + (i + 1));
            scoreTexts[i].text = PlayerPrefs.GetInt(SCORE_KEY + (i + 1)).ToString();
        }
    }
}
