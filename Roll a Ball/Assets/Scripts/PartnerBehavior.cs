using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerBehavior : MonoBehaviour
{
    private bool linked;
    public float speed;

    private void Start()
    {
        linked = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (linked == true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            GetComponent<Rigidbody>().AddForce(movement * speed);
        }
    }

    // Checks whether the player has collided with the partner
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            linked = true;
        }
    }
}
