using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCtrl : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float verticalSpeed;
    public float turnSpeed;
    public float jumpForce;
    private float groundlimit = -5;

    public GameObject fireballPrefab;
    public Transform fireballSpawnPoint;

    private Rigidbody playerRB;
    private bool isDead = false;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //vertical and horizontal movement
        if (isDead)
        {
            return;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * verticalSpeed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * turnSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        //if player falls of edge(doesnt work in alpha)
        if (transform.position.y <= groundlimit && !isDead)
        {
            Die();
            Debug.Log("Game Over");
        }
    }

    //detroy ghost on collision
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isDead)
        {
            Die();
        }
    }

    void SummonFireball()
    {
        if (fireballPrefab != null && fireballSpawnPoint != null)
        {
            GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, fireballSpawnPoint.rotation);
            Rigidbody fireballRB = fireball.GetComponent<Rigidbody>();

            if (fireballRB != null)
            {
                fireballRB.useGravity = false;
                fireballRB.AddForce(fireballSpawnPoint.forward * 70f, ForceMode.Impulse);
            }
        }
    }

    // Function to handle player death
    void Die()
    {
        isDead = true;
        Debug.Log("Player has died!");
    }
}



