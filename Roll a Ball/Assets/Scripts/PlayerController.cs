using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private int count;
    public Text countText;
    public Text winText;
    private bool isGrounded;
    public float jumpPower;
    //private bool hasLost;

    // Called at the start
    private void Start()
    {
        count = 0;
        SetCountText();
        winText.text = "";
    }

    // Moves the player based on controller input
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement * speed);

        if(GetComponent<Rigidbody>().position.y <= -50)
        {
            winText.text = "You lose...";
            if(GetComponent<Rigidbody>().position.y <= -150)
            {
                winText.text = "";
                GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
                GetComponent<Rigidbody>().position = new Vector3(0.0f, 0.5f, 0.0f);
            }
        }
    }

    // Checks whether our game object collides with a pickup object
    private void OnTriggerEnter(Collider other)
    {
        // For interactions with pickup objects
        if(other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }

    // Changes the count text to match count
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 8)
        {
            winText.text = "You Win!";
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            return;
        }

        isGrounded = true;
    }

    private void Update()
    {
        if(Input.GetButton("Jump") && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
