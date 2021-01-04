using System;
using System.Xml.Serialization;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // speed
    public float speed;

    private Rigidbody rigid;

    // score
    private int score;

    // health
    public int health = 5;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody> ();
    }

    // functions to allow the Player to move when either
    // the WASD or arrow keys are pressed
    void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(Horizontal, 0.0f, Vertical);

        rigid.AddForce (move * speed);
    }

    void OnTriggerEnter (Collider other)
    {
		if (other.tag == "Pickup")
        {
			score++;
			Destroy(other.gameObject);
			Debug.Log(string.Format("Score: {0}", score));
		}

        if (other.tag == "Trap")
        {
            health--;
            Debug.Log(string.Format("Health: {0}", health));
        }

        if (other.tag == "Goal")
        {
            Debug.Log("You win!");
        }

    }

    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
