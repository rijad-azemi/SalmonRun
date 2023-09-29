using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
	}
}
