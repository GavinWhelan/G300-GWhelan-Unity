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

    // If linked, moves the partner in relation to the player movement 
    private void FixedUpdate()
    {
        if (linked == true)
        {
            Vector3 movement;

            if (Vector3.Distance(GameObject.Find("Player").transform.position, GetComponent<Transform>().position) >= 2.0f)
            {
                movement = GameObject.Find("Player").transform.position - GetComponent<Transform>().position;
            }
            else
            {
                movement = GetComponent<Transform>().position - GameObject.Find("Player").transform.position;
            }

            GetComponent<Rigidbody>().AddForce(movement * speed);
        }
    }

    // Checks whether the player has collided with the partner
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player" || col.gameObject.tag == "Partner")
        {
            linked = true;
        }
    }

    /*
    // Checks whether our game object collides with a pickup object
    private void OnTriggerEnter(Collider other)
    {
        // For interactions with pickup objects
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
        }
    }
    */
}
