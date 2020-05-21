using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [Header("Set in Inspector")]

    public float SmoothTimeX;
    public float SmoothTimeY;
    public GameObject player;
    public float easing = 0.05f;

    private Vector3 pos;
    private Vector2 velocity;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        pos.z = -10;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        pos.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x, easing);
        pos.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y, easing);
        transform.position = pos;
    }
}
