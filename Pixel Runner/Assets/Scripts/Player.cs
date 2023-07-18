using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;

    [SerializeField]
    private float jumpSpeed = 1f;
    private bool isGround = true;

    void Start() 
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGround)
        {
            rigid.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
            isGround = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Foreground")
            isGround = true;
    }
}
