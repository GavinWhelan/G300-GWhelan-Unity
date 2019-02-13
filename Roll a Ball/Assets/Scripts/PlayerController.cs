using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private int count;
    public TextMeshProUGUI countText;

    // Called at the start
    private void Start()
    {
        count = 0;
        SetCountText();
    }

    // Moves the player based on controller input
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement * speed);
    }

    // Checks whether our game object collides with a pickup object
    private void OnTriggerEnter(Collider other)
    {
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
    }
}
