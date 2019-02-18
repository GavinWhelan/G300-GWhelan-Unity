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
    }

    // Checks whether our game object collides with a pickup object or a partner
    private void OnTriggerEnter(Collider other)
    {
        // For interactions with pickup objects
        if(other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }

        // For interactions with partners
        if(other.gameObject.tag == "Partner")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1000.0f, 0.0f, 0.0f));
        }
    }

    // Changes the count text to match count
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 6)
        {
            winText.text = "You Win!";
        }
    }
}
