using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public static Rigidbody2D rigid;
    [SerializeField] float horizontalMovement;
    [SerializeField] float verticalMovement;
    [SerializeField] int speed = 15;
    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] bool isGrounded = true;
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null) {
            rigid = GetComponent<Rigidbody2D>();
        }
         if (animator == null) {
            animator = GetComponent<Animator>();
        }
        // speed = 15;
        // jumpForce = 750.0f;

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump"))
			jumpPressed = true;
    }

    void Flip() {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }


    void Jump() {

        rigid.velocity = new Vector2(rigid.velocity.x, 0);
		rigid.AddForce(new Vector2(0, jumpForce));
        animator.SetInteger("motion", 2);
		jumpPressed = false;
		isGrounded = false;
    }

    void FixedUpdate()
    {

        if (!jumpPressed  && isGrounded) {
            if(horizontalMovement < 0 || horizontalMovement > 0) {
            animator.SetInteger("motion", 1);
            } else {
            animator.SetInteger("motion", 0);
            }
        }
        

        rigid.velocity = new Vector2(horizontalMovement * speed, rigid.velocity.y);
        if(horizontalMovement < 0 && isFacingRight || horizontalMovement > 0 && !isFacingRight) {
            Flip();
        }
        if (jumpPressed && isGrounded) {
            Jump();
        }
        // balloon.position = new Vector2(100, 0);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }
}
