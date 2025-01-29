using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public Animator anim;
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody2D RB;
    public bool isGrounded = false;
    public bool isJump = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isJump == true)
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (isGrounded == true)
        {
            RB.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
        }
    }

    public void checkCrouchTrue()
    {
        anim.SetBool("crouch" , true);
    }

    public void checkCrouchFalse()
    {
        anim.SetBool("crouch", false);
    }

    public void checkJumpTrue()
    {
        isJump = true;
    }

    public void checkJumpFalse()
    {
        isJump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
    }


}
