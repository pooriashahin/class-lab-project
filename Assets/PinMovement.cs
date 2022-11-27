using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D pin;
    [SerializeField] bool shot = false;

    // Start is called before the first frame update
    void Start()
    {
        if (pin == null) {
            pin = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pin.velocity.x < 0.01 && pin.velocity.x > -0.01 ) {
            Destroy(pin.gameObject);
        }

        if (pin.transform.position.x > 35 || pin.transform.position.x < -35 ) {
            Destroy(pin.gameObject);
        }
    }

    void Shoot() {
        shot = true;
    }

    void FixedUpdate()
    {
    }
   
}
