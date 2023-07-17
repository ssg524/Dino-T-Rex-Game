using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foreground : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 7f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x <= -17.85)
        {
            transform.position = new Vector3(17.99f, transform.position.y, 0);
        }
    }
}
