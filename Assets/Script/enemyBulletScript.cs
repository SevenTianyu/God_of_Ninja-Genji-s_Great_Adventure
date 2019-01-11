using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletScript : MonoBehaviour {
    private Rigidbody2D rBody;
    
	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "eWall")
        {
            gameObject.GetComponent<Transform>().Rotate(new Vector3(0, 0, 180));
            Vector2 v = rBody.velocity;
            v.x = -v.x;
            v.y = -v.y;
            rBody.velocity = v;
        }
        if (collision.tag == "ground")
        {
            if (gameObject.tag == "BBullet")
            {
                rBody.velocity = new Vector2(0, 0);
                Animator ani = gameObject.GetComponent<Animator>();
                ani.SetTrigger("boom");
                StartCoroutine(WaitandDestroy());
            }
            else Destroy(gameObject);
        }
        if (collision.tag == "Player")
        {
            if (gameObject.tag == "BBullet")
            {
                rBody.velocity = new Vector2(0, 0);
                Animator ani = gameObject.GetComponent<Animator>();
                ani.SetTrigger("boom");
                StartCoroutine(WaitandDestroy());
            }
            else Destroy(gameObject);
        }
        if (collision.tag == "enemy")
        {
            if (gameObject.tag == "bullet")
            {
                Destroy(gameObject);
            }
            else if (gameObject.tag == "playerBBullet")
            {
                rBody.velocity = new Vector2(0, 0);
                Animator ani = gameObject.GetComponent<Animator>();
                ani.SetTrigger("boom");
                StartCoroutine(WaitandDestroy());
            }
            
        }
    }

    IEnumerator WaitandDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }




}
