using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject player;
    public Transform spawnPoint;

    bool isGameActive = false;

    int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;

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

    // Spawn obstacles
    IEnumerator SpawnObstacle()
    {
        while (isGameActive)
        {
            float waitTime = Random.Range(0.6f, 2f);
            yield return new WaitForSeconds(waitTime);

            GameObject newObstacle = Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
            
            // Obstacles can spawn at different heights
            if (Random.Range(0, 5) == 0)
            {
                newObstacle.transform.Translate(Vector3.up * 2.5f);
            }

            newObstacle.GetComponent<Obstacle>().gameManager = this;
        }
    }

    public void GameStart()
    {
        isGameActive = true;
        player.SetActive(true);
        playButton.SetActive(false);
        StartCoroutine("SpawnObstacle");
    }
}
