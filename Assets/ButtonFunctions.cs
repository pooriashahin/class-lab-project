using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{

    [SerializeField] InputField NameField;
    [SerializeField] Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDifficulty() {
        PersistentData.Instance.SetDifficulty(dropdown.value);
    }

    public void GoToInstructions() {
        SceneManager.LoadScene("instructions");
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("main");
    }

    public void GoToScoreboard() {
        SceneManager.LoadScene("highestScores");
    }

    public void GoToSettings() {
        SceneManager.LoadScene("settings");
    }

    public void GoToLevel1() {
        string name = NameField.text;
        PersistentData.Instance.SetName(name);
        SceneManager.LoadScene("level1");
    }
}
