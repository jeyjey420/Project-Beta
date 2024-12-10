using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonCtrl : MonoBehaviour
{
    public Transform target;  
    public float moveSpeed = 3f; 

    private Rigidbody rb;  
    void Start()
    {
        rb = GetComponent<Rigidbody>();  
    }

    void Update()
    {
        if (target != null)
        {
            // direction to ghost
            Vector3 direction = (target.position - transform.position).normalized;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //skeleton collides enemy
            Destroy(collision.gameObject);
        }
    }
}
