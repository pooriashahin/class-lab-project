using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D pin;
    [SerializeField] GameObject controller;
    // [SerializeField] GameObject mario;
    [SerializeField] AudioSource audio;
    // [SerializeField] float horizontalMovement;
    // [SerializeField] float verticalMovement;
    [SerializeField] int speed = 0;
    [SerializeField] bool shot = false;
    // [SerializeField] float jumpForce = 750.0f;
    // [SerializeField] bool isFacingRight = true;
    // [SerializeField] bool shoot = false;
    // [SerializeField] bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        if (pin == null) {
            pin = GetComponent<Rigidbody2D>();
        }
        // speed = 35;
        // jumpForce = 750.0f;

        if (audio == null)
        {
            audio = GetComponent<AudioSource>();
        }

        if (controller == null) {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }

        // if (mario == null)
        // {
        //     mario = GameObject.FindGameObjectWithTag("mario");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        // horizontalMovement = Input.GetAxis("Horizontal");
        // verticalMovement = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Fire1"))
			Shoot();
    }

    void Flip() {
        // transform.Rotate(0, 180, 0);
        // isFacingRight = !isFacingRight;
    }


    void Shoot() {
        shot = true;
        speed = 45;
        // pin.velocity = new Vector2(rigid.velocity.x, 0);
		// rigid.AddForce(new Vector2(0, jumpForce));
		// jumpPressed = false;
		// isGrounded = false;
    }

    void FixedUpdate()
    {

        pin.velocity = new Vector2(speed, pin.velocity.y);
        // if(horizontalMovement < 0 && isFacingRight || horizontalMovement > 0 && !isFacingRight) {
        //     Flip();
        // }
        // if (jumpPressed && isGrounded) {
        //     Jump();
        // }
        // balloon.position = new Vector2(100, 0);
        if(pin.position.x < -6 || pin.position.x > 38) {
            ResetPin();
        }

        if (shot == false) {
            pin.position = new Vector2(Movement.rigid.position.x, Movement.rigid.position.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "myBalloon") {
            Debug.Log("POP");
        }
    }

    void ResetPin() {

        speed = 0;
        shot = false;
        
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag  == "myBalloon") {
            Debug.Log("POP");
            /* when Mario collides with the coin:
            * 1. increase score
            * 2, play sound effect
            * 3. make coin disappear */


            //1. increase score
            controller.GetComponent<ScoreKeeper>().addScore();
            // controller.GetComponent<Scorekeeper>().AddPoints();

            //2. play sound effect
            audio.Play();
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);

            //3. coin should disappear
            Destroy(other.gameObject);
        }
       
    }
}
