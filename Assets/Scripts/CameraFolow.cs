using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour {

    public GameObject player;       //Public variable to store a reference to the player game object


    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z-17.0f);
    }
}