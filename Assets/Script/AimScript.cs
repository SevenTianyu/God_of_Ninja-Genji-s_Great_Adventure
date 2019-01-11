using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour {

    public GameObject boss;
    public GameObject player;
    public float smoothTime0 = 0.1f;  //图片平滑移动的时间
 
    private Vector3 cameraVelocity = Vector3.zero;
    private bool canQ=true;

    private float posx;
    private float posy;
   
    // Use this for initialization
    void Start()
    {
        posx = transform.position.x;
        posy = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.GetComponent<Animator>().GetBool("isQ") && canQ)
        {
            //瞄准跟踪
            if(!player.GetComponent<SpriteRenderer>().flipX)
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.GetComponent<Transform>().position.x+0.5F, player.GetComponent<Transform>().position.y, 0), ref cameraVelocity, smoothTime0);
            else transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.GetComponent<Transform>().position.x - 0.5F, player.GetComponent<Transform>().position.y, 0), ref cameraVelocity, smoothTime0);
            StartCoroutine(WaitQ());
        }
        else {
           transform.position = new Vector3(posx, posy, 0);

        }

    }
    IEnumerator WaitQ()
    {
        yield return new WaitForSeconds(2);
        canQ = false;
        yield return new WaitForSeconds(5);
        canQ = true;
    }
  
}
