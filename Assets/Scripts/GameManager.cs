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
    
    private bool soundtoggle = false;

    [SerializeField] private GameObject PlayerCharacter;
    [SerializeField] private Transform  positionPlayer;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject controllerButton;
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text FinalScoreText;

    [SerializeField] private Sprite SoundOn;
    [SerializeField] private Sprite SoundOff;
    [SerializeField] private Image image;
    [SerializeField] private AudioSource BgSound;

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
        image.sprite = SoundOn;
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
        pauseButton.SetActive(true);
        controllerButton.SetActive(true);

        BgSound.Stop();
        BgSound.Play();

        gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;

        gameSpeed = 0f;
        enabled = false;

        pauseButton.SetActive(false);
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
        score += gameSpeed * Time.deltaTime * 10;
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

        pauseButton.SetActive(true);
        controllerButton.SetActive(true);
        pauseMenuPanel.SetActive(false);
    }

    public void StartGame()
    {
        NewGame();
        Time.timeScale = 1f;

        StartMenu.SetActive(false);
    }

    public void SoundToggleButton()
    {
        if(!soundtoggle)
        {
            soundtoggle = true;
            image.sprite = SoundOff;
            BgSound.Pause();
        }
        else
        {
            soundtoggle = false;
            image.sprite = SoundOn;
            BgSound.Play();
        }
    }
}
