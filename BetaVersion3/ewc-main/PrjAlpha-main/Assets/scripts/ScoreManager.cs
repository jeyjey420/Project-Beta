using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public skeletonSpawner skeletonSpawner;
    public EnemySpawner enemySpawner;
    public int score = 0;
    public Text scoreText;

    public bool canUseFreezePowerUp = false; // Tracks when the player can use the power-up

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();

        // Grant power-up every 10 kills
        if (score % 10 == 0)
        {
            canUseFreezePowerUp = true;
            Debug.Log("Freeze Power-Up Ready!");
        }

        // Spawn skeletons and increase difficulty (existing logic)
        if (score % 15 == 0)
        {
            skeletonSpawner.SpawnSkeleton();
        }

        if (score % 8 == 0)
        {
            Enemy.speed += 0.5f;
        }

        if (score % 10 == 0)
        {
            enemySpawner.IncreaseDifficulty();
        }
    }

    public int GetScore()
    {
        return score;
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
