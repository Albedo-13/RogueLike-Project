using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotShooting : MonoBehaviour
{
    public GameObject Player;
    public GameObject spawn;
    public GameObject Bullet2;

    public float Cooldown = 2f;
    public float TimeCount = 2f;
    public float RaycastRange = 1f;

    private Vector3 playerPos;
    public Vector2 direc;
    public RaycastHit2D hit;

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerPos = Player.transform.position;
        direc = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y);
        transform.right = direc;
        
        //Просто визуализация луча
        Debug.DrawRay(transform.position, direc);
        
        hit = Physics2D.Raycast(transform.position, direc);

        if (hit.collider.tag == "Player" || hit.collider.tag == "Bullet")
        {
            if(TimeCount < Time.time)
            {
                TimeCount = Cooldown + Time.time;
                GameObject progectile1 = Instantiate(Bullet2, spawn.transform.position, Quaternion.identity);
                progectile1.transform.right = transform.right;
            }
            
        }
    }
}
