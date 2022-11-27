using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] Slider slider;
    // [SerializeField] AudioListener audio;
    // Start is called before the first frame update
    void Start()
    {
       if (slider == null) {
        slider = GetComponent<Slider>();
       }
     
    }

    public void ChangeVolume() {
        AudioListener.volume = slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        // listener.Volume = gameObject.value;
    }
}
