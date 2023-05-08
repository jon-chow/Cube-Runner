using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject player;
    public Transform spawnPoint;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject pauseButton;

    bool isGameActive = false;
    bool isPaused = true;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update the score
    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    // Create an obstacle
    void CreateObstacle()
    {
        GameObject newObstacle = Instantiate(obstacle, spawnPoint.position, Quaternion.identity);

        // Obstacles can spawn at different heights
        if (Random.Range(0, 5) == 0)
        {
            newObstacle.transform.Translate(Vector3.up * 2.5f);
        }

        newObstacle.GetComponent<Obstacle>().gameManager = this;
    }

    // Spawn obstacles
    IEnumerator SpawnObstacle()
    {
        // Check if the game is still active before spawning an obstacle
        while (isGameActive)
        {
            float waitTime = Random.Range(0.6f, 2f);
            yield return new WaitForSeconds(waitTime);

            if (!isPaused)
            {
                CreateObstacle();
            }
        }
    }

    // Start the game
    public void GameStart()
    {
        // Spawn obstacles on game start
        if (!isGameActive)
        {
            isGameActive = true;
            isPaused = false;
            StartCoroutine("SpawnObstacle");
        }
        
        isPaused = false;
        player.SetActive(true);
        playButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    // Pause the game
    public void TogglePause()
    {
        if (!isPaused)
        {
            isPaused = true;
            pauseButton.SetActive(false);
            playButton.SetActive(true);
        }
        else
        {
            isPaused = false;
            pauseButton.SetActive(true);
            playButton.SetActive(false);
        }
    }

    // Getter for isPaused
    public bool IsPaused()
    {
        return isPaused;
    }
}
