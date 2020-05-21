using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour {

    public Vector3 mousePos;
    public float easing = 0.01f;

    private Vector3 pos;

    // Use this for initialization
    void Start () {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }
	
	// Update is called once per frame
	void Update () {

        pos.x = Mathf.Lerp(this.transform.position.x, mousePos.x, easing);
        pos.y = Mathf.Lerp(this.transform.position.y, mousePos.y, easing);
        transform.position = pos;
            
        Destroy(this.gameObject, 1.5f);
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
