using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public static Rigidbody2D rigid;
    [SerializeField] float horizontalMovement;
    [SerializeField] float verticalMovement;
    [SerializeField] bool isShot;
    [SerializeField] int speed = 15;
    [SerializeField] float jumpForce = 5000.0f;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] bool isGrounded = true;
    [SerializeField] Animator animator;
    [SerializeField] GameObject fire;
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
        isShot = Input.GetButtonDown("Fire1");
        if (Input.GetButtonDown("Jump"))
			jumpPressed = true;

        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
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
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }

    void Shoot() {
        int direction = isFacingRight ? 1 : -1;
        Vector2 position = new Vector2(rigid.position.x + direction/10, rigid.position.y);
        GameObject pin = Instantiate(fire, position, Quaternion.identity);
        pin.SetActive(true);
        if (direction == -1)
            pin.transform.Rotate(0, 180, 0);
        pin.GetComponent<Rigidbody2D>().velocity = new Vector2(100000 * direction, rigid.velocity.y);
    }
}
