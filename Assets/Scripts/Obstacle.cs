using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameManager gameManager;
    Material material;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        // Set a random material for the obstacle
        material = GetComponent<Renderer>().material;
        material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        // Set a random speed for the obstacle
        speed = Random.Range(10f, 12f) * -1f;
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
    }
    
    // Destroy the obstacle when it becomes invisible
    private void OnBecomeInvisible()
    {
        gameManager.UpdateScore();
        Destroy(gameObject);
    }
}
