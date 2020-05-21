using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovementScript : MonoBehaviour {

    private Rigidbody2D rb;
    float MoveWithX;
    float MoveWithY;
    public float maxSpeed = 2f;

    public GameObject Blood;
    public GameObject DeadBody;
    public static int HealthPoints;

    public Text HealthTextBlock;

	// Use this for initialization
	void Start () {
        HealthPoints = 100;
        rb = GetComponent<Rigidbody2D>();

        GameObject HUI = GameObject.Find("HealthUI");
        HealthTextBlock = HUI.GetComponent<Text>();

        HealthTextBlock.text = "100";
	}
	
	// Update is called once per frame
	void Update () {
        MoveWithY = Input.GetAxis("Horizontal") * maxSpeed;
        rb.velocity = new Vector2(MoveWithY * maxSpeed, rb.velocity.y);

        MoveWithX = Input.GetAxis("Vertical") * maxSpeed;
        rb.velocity = new Vector2(rb.velocity.x, MoveWithX * maxSpeed);

        IsDead();
    }

    private void IsDead()
    {
        if (HealthPoints <= 0)
        {
            var pos = DeadBody.transform.position;
            pos.z = -1;

            Instantiate(DeadBody, new Vector3(transform.position.x, transform.position.y, pos.z), transform.rotation);
            SceneManager.LoadScene(2);
            Destroy(gameObject);
        }
    }

    private void HealthAdd(int health)
    {
        int temp = int.Parse(HealthTextBlock.text);
        temp += health;
        HealthTextBlock.text = temp.ToString();
    }

    private void HealthRemove(int health)
    {
        int temp = int.Parse(HealthTextBlock.text);
        temp -= health;
        HealthTextBlock.text = temp.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            var pos = DeadBody.transform.position;
            pos.z = -1;

            HealthRemove(25);
            HealthPoints -= 25;
            
            Instantiate(Blood, new Vector3(transform.position.x, transform.position.y, pos.z), transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish" && GameObject.FindGameObjectsWithTag("Bot").Length <= 2)
        {
            Debug.Log("Finished level!");
            SceneManager.LoadScene(2);
        }
        else if (GameObject.FindGameObjectsWithTag("Bot").Length > 2)
        {
            Debug.Log("Чертовы гуки еще живы, Джонни");
        }
        if (collision.gameObject.tag == "Heal")
        {
            HealthAdd(50);
            HealthPoints += 50;
            Destroy(collision.gameObject);
        }
    }
}
