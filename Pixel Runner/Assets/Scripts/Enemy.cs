using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -11) {
            Destroy(gameObject);
        }
    }
}
