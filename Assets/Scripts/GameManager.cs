using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }

    [SerializeField] private GameObject PlayerCharacter;
    [SerializeField] private Transform  positionPlayer;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject controllerButton;
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text FinalScoreText;

    private Obstacle_Generator obstacleGenerator;

    private float score;

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
        obstacleGenerator = FindObjectOfType<Obstacle_Generator>();
        Time.timeScale = 0f;
    }

    public void NewGame()
    {
        Time.timeScale = 1f;
        score = 0;

        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        foreach (var obstacle in obstacles) 
        {
            Destroy(obstacle.gameObject);
        }

        PlayerCharacter.transform.position = positionPlayer.position;

        gameSpeed = initialGameSpeed;
        enabled = true;

        PlayerCharacter.SetActive(true);
        obstacleGenerator.gameObject.SetActive(true);
        controllerButton.SetActive(true);

        gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;

        gameSpeed = 0f;
        enabled = false;

        controllerButton.SetActive(false);
        obstacleGenerator.gameObject.SetActive(false);

        FinalScoreText.text = Mathf.FloorToInt(score).ToString("D6");
        gameOverPanel.SetActive(true);

    }

    private void Update()
    {
        scoreCount();
    }

    public void scoreCount()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D6");
    }

    public void PauseMenu()
    {
        Time.timeScale = 0f;

        controllerButton.SetActive(false);
        pauseMenuPanel.SetActive(true);

    }

    public void Resume()
    {
        Time.timeScale = 1f;

        controllerButton.SetActive(true);
        pauseMenuPanel.SetActive(false);
    }

    public void StartGame()
    {
        NewGame();
        Time.timeScale = 1f;

        StartMenu.SetActive(false);
    }
}
