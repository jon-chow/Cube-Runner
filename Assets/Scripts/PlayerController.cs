using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public GameManager gameManager;
    Rigidbody rb;
    bool canJump;

    // Get the rigidbody component
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Jump when the player taps on the screen, or presses the space bar
        if ((Input.GetKeyDown(KeyCode.Space)
            || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            && canJump
            && !gameManager.IsPaused())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
        // Freeze the player if the game is paused
        rb.isKinematic = gameManager.IsPaused();
    }

    // Player can jump when touching the ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

    // Player can't jump when not touching the ground
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }

    // Game restarts when touching an obstacle
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
