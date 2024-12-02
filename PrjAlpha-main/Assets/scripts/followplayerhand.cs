using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayerhand : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

  
    void Update()
    {
        // Set the position of this object to the player's position
        transform.position = player.transform.position + player.transform.forward * 1.0f + player.transform.up * 1.5f;
    }
}

