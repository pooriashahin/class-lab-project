using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{

    [SerializeField] int score = 0;
    [SerializeField] Text scoreText;
    [SerializeField] Text levelText;
    [SerializeField] int level;

    const int DEFAULT_POINTS = 1;
    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        scoreText.text = "Score: " + score;
        levelText.text = "Level " + (level + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore() {
        addScore(DEFAULT_POINTS);
        scoreText.text = "Score: " + score;
        
        if (score == 1) {
            UpdateLevel();
        }
    }

    public void addScore(int added) {

        score += added;
        Debug.Log("score" + score);
    }

    void UpdateLevel() {
        SceneManager.LoadScene(level + 1);
    }
}
