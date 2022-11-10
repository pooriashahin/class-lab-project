using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{

    [SerializeField] float score = 0.0f;
    [SerializeField] Text scoreText;
    [SerializeField] Text levelText;
    [SerializeField] int level;

    const int DEFAULT_POINTS = 1;
    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex - 1;
        scoreText.text = "Score: " + score;
        levelText.text = "Level " + (level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore() {
        addScore(DEFAULT_POINTS);
        scoreText.text = "Score: " + score;
        
        if (score > 0.25) {
            UpdateLevel();
        }
    }

    public void addScore(float added) {

        score += added;
        scoreText.text = "Score: " + score;
         if (score > 0.50) {
            UpdateLevel();
        }
        Debug.Log("score" + score);
    }

    void UpdateLevel() {
        SceneManager.LoadScene(level + 2);
    }
}
