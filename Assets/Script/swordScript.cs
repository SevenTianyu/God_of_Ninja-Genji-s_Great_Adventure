using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordScript : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "enemy")
        {
            Destroy(gameObject);


        }

    }
}
