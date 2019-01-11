using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, 360) * Time.deltaTime);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}
