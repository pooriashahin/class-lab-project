using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{

    [SerializeField] InputField NameField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToInstructions() {
        SceneManager.LoadScene("instructions");
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("main");
    }

    public void GoToLevel1() {
        string name = NameField.text;
        PersistentData.Instance.SetName(name);
        SceneManager.LoadScene("level1");
    }
}
