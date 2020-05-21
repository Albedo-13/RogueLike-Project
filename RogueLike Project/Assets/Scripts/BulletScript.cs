using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float speed = 50f;

    // Update is called once per frame
    void FixedUpdate () {

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
