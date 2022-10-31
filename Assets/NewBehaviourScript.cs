using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] Rigidbody2D balloon;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = -1.5f;
            if (balloon == null) {

            balloon = GetComponent<Rigidbody2D>();
        }
        InvokeRepeating("Grow", 1.0f, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate() {
        balloon.velocity = new Vector2(speed, balloon.velocity.y);
        if(balloon.position.x < -6 || balloon.position.x > 18) {
            Flip();
        }

        
    }

    void Flip() {
        transform.Rotate(0, 180, 0);
        speed=-speed;
        balloon.velocity = new Vector2(speed, balloon.velocity.y);
    }

    void Grow() {
        transform.localScale = transform.localScale + new Vector3(0.01f, 0.01f);
    }

       
}
