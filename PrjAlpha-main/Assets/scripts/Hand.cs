using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject fireBallSpawnPoint;
    [SerializeField]
    private GameObject sphere;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(sphere, fireBallSpawnPoint.transform.position, fireBallSpawnPoint.transform.rotation);
        }
    }
}