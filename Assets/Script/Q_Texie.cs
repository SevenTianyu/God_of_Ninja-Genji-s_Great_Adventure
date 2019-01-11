using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q_Texie : MonoBehaviour
{

    public GameObject texie;
    public GameObject character;   //图片要跟随的人物
  
    public Sprite sp2;
    public float smoothTime0  ;  //图片平滑移动的时间
    public float smoothTime1  ;
    private int i = 0;
    private Vector3 cameraVelocity = Vector3.zero;

    public bool canDo=true;
    private bool canQ = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canDo)
        {
            if (!(Input.GetKeyDown(KeyCode.Q)))
            {
                if (i == 0)
                {
                    texie.GetComponent<SpriteRenderer>().sprite = null;
                }
                if (i == 1)
                {
                    texie.GetComponent<SpriteRenderer>().sprite = sp2;
                }

                texie.GetComponent<Transform>().position = Vector3.SmoothDamp(texie.GetComponent<Transform>().position, new Vector3(character.GetComponent<Transform>().position.x, -4, 0) + new Vector3(-6, 8, 0), ref cameraVelocity, smoothTime0);



            }

            else if (canQ)
            {
                if (i == 0)
                {
                    texie.GetComponent<SpriteRenderer>().sprite = null;
                }
                if (i == 1)
                {
                    texie.GetComponent<SpriteRenderer>().sprite = sp2;
                }
                i = 1;
                Texie();
                StartCoroutine(Wait());
                StartCoroutine(WaitQ());
                canQ = false;
                //flag = 0;
            }
        }
           
       
       
    }
    //语句外提 解决了短时间多内次按Q出现的Bug
    private void Texie()
    {
      
        
        texie.GetComponent<Transform>().position = Vector3.SmoothDamp(texie.GetComponent<Transform>().position, new Vector3(character.GetComponent<Transform>().position.x, -4, 0) + new Vector3(20, 8, 0), ref cameraVelocity, smoothTime1);
        //yield return new WaitForSeconds(1.2F);
        
        
    }
    IEnumerator WaitQ()
    {
        yield return new WaitForSeconds(30);
        canQ = true;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2F);
        i = 0;
    }

}