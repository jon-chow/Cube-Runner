using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameManager gameManager;
    Material material;
    float speed;
    bool isRotatingClockwise;
    bool isRotatingCounterClockwise;

    // Start is called before the first frame update
    void Start()
    {
        // Set a random material for the obstacle
        material = GetComponent<Renderer>().material;
        material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        // Set a random speed for the obstacle
        speed = Random.Range(10f, 12f) * -1f;

        // Set a random rotation for the obstacle
        if (Random.Range(0, 3) == 0)
        {
            // Clockwise rotation
            if (Random.Range(0, 2) == 0)
            {
                isRotatingClockwise = true;
            }
            // Counter-clockwise rotation
            else
            {
                isRotatingCounterClockwise = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.IsPaused())
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (transform.position.z < -5)
        {
            OnBecomeInvisible();
        }

        // Clockwise rotation
        if (isRotatingClockwise)
        {
            transform.Rotate(Vector3.forward * 5f * Time.deltaTime);
        }
        // Counter-clockwise rotation
        else if (isRotatingCounterClockwise)
        {
            transform.Rotate(-Vector3.forward * 5f * Time.deltaTime);
        }
    }
    
    // Destroy the obstacle when it becomes invisible
    private void OnBecomeInvisible()
    {
        gameManager.UpdateScore();
        Destroy(gameObject);
    }
}
