using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    public GameObject Bullet1;
    public GameObject spawn;

    public float Cooldown = 0.25f;
    public float TimeCount = 0.25f;
	
	// Update is called once per frame
	void Update () {

        faceMouse();

        if (Input.GetButtonDown("Fire1") && Time.time > TimeCount)
        {
            TimeCount = Cooldown + Time.time;
            GameObject progectile1 = Instantiate(Bullet1, spawn.transform.position,Quaternion.identity);
            progectile1.transform.right = transform.right;
        }
        if (Input.GetButton("Fire1") && Time.time > TimeCount)
        {
            TimeCount = Cooldown + Time.time;
            GameObject progectile1 = Instantiate(Bullet1, spawn.transform.position, Quaternion.identity);
            progectile1.transform.right = transform.right;
        }
    }

    void faceMouse()
    {
        Vector3 mousepos = Input.mousePosition;
        mousepos.z = 10;
        mousepos = Camera.main.ScreenToWorldPoint(mousepos);
        Vector2 direc = new Vector2(mousepos.x - transform.position.x, mousepos.y - transform.position.y);
        transform.right=direc;
    }
}
