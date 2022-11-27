using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] Rigidbody2D balloon;
    [SerializeField] float speed;
    [SerializeField] public double balloonScore = 10.0;
    [SerializeField] GameObject controller;
    [SerializeField] AudioSource audio;
    [SerializeField] Animator animator;
    [SerializeField] bool isPopped = false;
    [SerializeField] int level = SceneManager.GetActiveScene().buildIndex - 1;

    // Start is called before the first frame update
    void Start()
    {
        speed = -1.5f;
        if (balloon == null) {
            balloon = GetComponent<Rigidbody2D>();
        }

        InvokeRepeating("Grow", 1.0f, 1.0f);

        if (controller == null) {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }

        if (audio == null)
        {
            audio = GetComponent<AudioSource>();
        }

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate() {
        balloon.velocity = new Vector2(speed, balloon.velocity.y);
        if(balloon.position.x < -20 || balloon.position.x > 30) {
            Flip();
        }

        if (transform.localScale.x > 0.75) {
            Destroy(gameObject);
            SceneManager.LoadScene(level + 2);
        }

        
    }

    void Flip() {
        transform.Rotate(0, 180, 0);
        speed=-speed;
        balloon.velocity = new Vector2(speed, balloon.velocity.y);
    }

    void Grow() {
        transform.localScale = transform.localScale + new Vector3(0.01f, 0.01f);
        balloonScore *= 0.9;
    }

        private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag  == "myPin" && !isPopped) {
            isPopped = true;
            /* when Mario collides with the coin:
            * 1. increase score
            * 2, play sound effect
            * 3. make coin disappear */


            //1. increase score
            controller.GetComponent<ScoreKeeper>().addScore(Mathf.FloorToInt(3.75f / gameObject.transform.localScale.x));

            //2. play sound effect
            animator.SetInteger("explode", 1);
        
            // audio.Play();
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);

            //3. coin should disappear
            Invoke("Kill", 1);
        }
       
    }

    void Kill() {
        Destroy(gameObject);
    }
}
