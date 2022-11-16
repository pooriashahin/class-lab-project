using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentData : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] float playerScore;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName (string name) {
        playerName = name;
    }

    public void SetScore (float score) {
        playerScore = score;
    }

    public string GetName () {
        return playerName;
    }

    public float GetScore () {
        return playerScore;
    }
}
