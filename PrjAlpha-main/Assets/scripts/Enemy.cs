using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float speed = 2f; 
    public EnemySpawner spawner;
    private Vector3 randomDirection;

    void Start()
    {
        randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        StartCoroutine(ChangeDirection());

        if (Random.value < 0.2f) 
        {
            speed += 2f; 
            gameObject.GetComponent<Renderer>().material.color = Color.red; 
        }
    }

    void Update()
    {
        transform.Translate(randomDirection * speed * Time.deltaTime);
    }

    IEnumerator ChangeDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        }
    }

    private void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.DecrementEnemyCount();
        }
    }
}
