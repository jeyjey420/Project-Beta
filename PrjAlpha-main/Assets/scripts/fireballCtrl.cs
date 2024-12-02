using UnityEngine;
using UnityEngine.SceneManagement;

public class FireballCtrl : MonoBehaviour
{
    public float shootForce;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shootForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);

            ScoreManager.Instance.AddScore(1);
        }

        Destroy(gameObject);
    }
}







