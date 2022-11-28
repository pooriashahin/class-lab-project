using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentData : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] int playerScore;
    [SerializeField] int difficultyLevel;
    public static PersistentData Instance;
    
    void Awake() {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerName = "";
        playerScore = 0;
        difficultyLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName (string name) {
        playerName = name;
    }

    public void SetDifficulty (int difficulty) {
        difficultyLevel = difficulty;
    }

    public void SetScore (int score) {
        playerScore = score;
    }

    public string GetName () {
        return playerName;
    }

    public int GetScore () {
        return playerScore;
    }

    public string GetDifficulty () {
        return difficultyLevel == 1 ? "Difficult" : "Easy";
    }
}
