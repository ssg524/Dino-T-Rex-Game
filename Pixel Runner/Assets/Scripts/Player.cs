using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator animator;

    [SerializeField]
    private float jumpSpeed;
    private bool isGround = true;

    void Start() 
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Jump();
        Sit();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGround)
        {
            rigid.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
            isGround = false;
            animator.SetBool("isJump", true);
        }
    }

    void Sit()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && isGround)
        {
            animator.SetBool("isDown", true);
        } else if (Input.GetKeyUp(KeyCode.DownArrow) && isGround)
        {
            animator.SetBool("isDown", false);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Foreground") {
            isGround = true;
            animator.SetBool("isJump", false);
        }
    } 

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") { 
            if (!animator.GetBool("isDown"))
                animator.SetTrigger("isDie_RUN");
            else
                animator.SetTrigger("isDie_SIT");
            GameManager.instance.SetGameOver();
        }
    }
}
