using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    private Vector3 offset;

    // Sets camera offset value
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Updates camera position based on player movement
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
