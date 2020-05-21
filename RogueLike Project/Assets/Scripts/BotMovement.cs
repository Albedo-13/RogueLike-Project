using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour {
    
    public float speed = 1f;

    public GameObject Player;
    private Vector3 pos;
    private float ShootingRange;

    private int HealthPoints;
    public GameObject Blood;
    public GameObject DeadBody;
    public GameObject OwnGun;

    private Vector3 playerPos;
    public Vector2 direc;
    public RaycastHit2D hit;

    // Update is called once per frame
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        HealthPoints = 100;
        ShootingRange = Random.Range(20f, 40.4f);
        
    }

    void FixedUpdate () {
        FaceToPlayer();
        IsDead();
        
        playerPos = Player.transform.position;
        direc = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y);

        hit = Physics2D.Raycast(OwnGun.transform.position, direc);
        Debug.DrawRay(OwnGun.transform.position, direc);

        if (hit.collider.tag == "Player" || hit.collider.tag == "Bullet")
        {
            if (Vector3.Distance(transform.position, Player.transform.position) >= ShootingRange)
            {
                pos = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
                transform.position = pos;
            }
            else if (Vector3.Distance(transform.position, Player.transform.position) < ShootingRange - 3)
            {
                pos = Vector3.MoveTowards(transform.position, Player.transform.position, -1 * speed * Time.deltaTime);
                transform.position = pos;
            }
        }
    }

    private void IsDead()
    {
        if (HealthPoints <= 0)
        {
            var pos = DeadBody.transform.position;
            pos.z = -1;

            Destroy(gameObject);
            Instantiate(DeadBody, new Vector3(transform.position.x, transform.position.y, pos.z), transform.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            var pos = DeadBody.transform.position;
            pos.z = -1;

            HealthPoints -= 25;
            Instantiate(Blood, new Vector3(transform.position.x, transform.position.y, pos.z), transform.rotation);
        }
    }

    void FaceToPlayer()
    {
        Vector3 toView = Player.transform.position;
        Vector2 direc = new Vector2(toView.x - transform.position.x, toView.y - transform.position.y);
        transform.right = direc;
    }
}