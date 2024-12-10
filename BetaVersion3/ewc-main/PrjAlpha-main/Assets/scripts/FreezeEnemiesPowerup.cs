using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEnemiesPowerUp : MonoBehaviour
{
    public void FreezeAllEnemies()
    {
        StartCoroutine(FreezeEnemiesForDuration(5f)); // Freeze for 5 seconds
    }

    private IEnumerator FreezeEnemiesForDuration(float duration)
    {
        Enemy.speed = 0f; // freeze all enemies

        yield return new WaitForSeconds(duration);

        Enemy.speed = 2f; // Reset enemy speed to normal
        Debug.Log("Enemies unfrozen.");
    }
}
