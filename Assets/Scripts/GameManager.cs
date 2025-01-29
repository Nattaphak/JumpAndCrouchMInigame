using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }


    [SerializeField] private GameObject gameOverPanel;

    private Player player;
    private Obstacle_Generator obstacleGenerator;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        obstacleGenerator = FindObjectOfType<Obstacle_Generator>();
        NewGame();
    }

    public void NewGame()
    {
        Time.timeScale = 1f;

        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        foreach (var obstacle in obstacles) 
        {
            Destroy(obstacle.gameObject);
        }

        gameSpeed = initialGameSpeed;
        enabled = true;

        player.gameObject.SetActive(true);
        obstacleGenerator.gameObject.SetActive(true);

        gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;

        gameSpeed = 0f;
        enabled = false;

        //player.gameObject.SetActive(false);
        obstacleGenerator.gameObject.SetActive(false);

        gameOverPanel.SetActive(true);

    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
    }
}
