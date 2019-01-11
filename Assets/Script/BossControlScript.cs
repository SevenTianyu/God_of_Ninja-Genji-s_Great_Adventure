using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossControlScript : MonoBehaviour {
    public GameObject Ebullet;
    public GameObject Player;
    public GameObject BBullet;
    public AudioSource as1;
    public GameObject bosshp;
    public int Hp=100;
    private GameObject[] Bosshp;
    private Rigidbody2D rBody;

    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public GameObject hp4;
    public GameObject hp5;
    public GameObject hp6;
    public GameObject icon;
    public GameObject j;
    public GameObject e;
    public GameObject q;
    public GameObject jcdi;
    public GameObject ecdi;
    public GameObject qcdi;

    public GameObject warn;

    private Animator ani;
    private int dieTime=0;

    public bool canDo=true;
    private int i=0;
    // Use this for initialization
    void Start () {
        rBody = GetComponent<Rigidbody2D>();
        Bosshp = new GameObject[100];
        for (int i = 0; i < 100; i++)
        {
            Bosshp[i] = Instantiate(bosshp, new Vector3(-5 + 0.1F * i, 3.5F, 0), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        }
        ani = GetComponent<Animator>();
        
        
	}
	
	// Update is called once per frame
	void Update () {

        if (canDo&i==0)
        {
            Move();
            i++;
        }
        if (Hp <= 0 && dieTime == 0)
            {

                AudioManager.Instance.PlaySound("【麦克雷】死亡");

                if (GetComponent<SpriteRenderer>().flipX)
                {

                    rBody.velocity = new Vector2(-4, 8);
                }
                else if (!GetComponent<SpriteRenderer>().flipX)
                {
                    rBody.velocity = new Vector2(4, 8);
                }
                Destroy(GameObject.Find("bossText"));
                Destroy(GetComponent<BoxCollider2D>());

                dieTime = 1;
                StartCoroutine(BossDie());
           
        
        }

      
    }

    private void Move()
    {
        StartCoroutine(WaitAndMove());
    }

    IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(3);
        //左下
        GameObject warn1 = Instantiate(warn, new Vector3(-4.6F, -3.59F, 10), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        yield return new WaitForSeconds(0.5F);
        warn1.SetActive(false);
        yield return new WaitForSeconds(0.5F);
        warn1.SetActive(true);
        yield return new WaitForSeconds(0.5F);
        warn1.SetActive(false);
        yield return new WaitForSeconds(0.5F);
        GetComponent<Transform>().position = new Vector3(-4.6F,-3.59F,10);
        GetComponent<SpriteRenderer>().flipX = true;
        yield return new WaitForSeconds(1);
        Fire2();
        yield return new WaitForSeconds(3);
        //左上
        GameObject warn2 = Instantiate(warn, new Vector3(-4.6F, 1.32F, 10), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        yield return new WaitForSeconds(0.5F);
        warn2.SetActive(false);
        yield return new WaitForSeconds(0.5F);
        warn2.SetActive(true);
        yield return new WaitForSeconds(0.5F);
        warn2.SetActive(false);
        yield return new WaitForSeconds(0.5F);
        GetComponent<Transform>().position = new Vector3(-4.6F, 1.32F, 10);
        yield return new WaitForSeconds(1);
        Fire();
        yield return new WaitForSeconds(0.07F);
        Fire();
        yield return new WaitForSeconds(0.07F);
        Fire();
        yield return new WaitForSeconds(0.07F);
        Fire();
        yield return new WaitForSeconds(0.07F);
        Fire();
        yield return new WaitForSeconds(0.07F);
        Fire();
        yield return new WaitForSeconds(3);
        //右上
        GameObject warn3 = Instantiate(warn, new Vector3(5, 1.32F, 10), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        yield return new WaitForSeconds(0.5F);
        warn3.SetActive(false);
        yield return new WaitForSeconds(0.5F);
        warn3.SetActive(true);
        yield return new WaitForSeconds(0.5F);
        warn3.SetActive(false);
        yield return new WaitForSeconds(0.5F);
        GetComponent<Transform>().position = new Vector3(5, 1.32F, 10);
        GetComponent<SpriteRenderer>().flipX = false;
        yield return new WaitForSeconds(1);
        Fire();
        yield return new WaitForSeconds(0.07F);
        Fire();
        yield return new WaitForSeconds(0.07F);
        Fire();
        yield return new WaitForSeconds(0.07F);
        Fire();
        yield return new WaitForSeconds(0.07F);
        Fire();
        yield return new WaitForSeconds(0.07F);
        Fire();
        yield return new WaitForSeconds(5);
        //大招状态
        ani.SetBool("isQ", true);
        as1.volume = 0.2F;
        AudioManager.Instance.PlaySound("【麦克雷】午时已到。");
        //午时已到
        yield return new WaitForSeconds(2);
        GameObject bbullteMove = Instantiate(BBullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        float x = GetComponent<Transform>().position.x - Player.transform.position.x;
        float y = GetComponent<Transform>().position.y - Player.transform.position.y;
        bbullteMove.GetComponent<Transform>().Rotate(new Vector3(0, 0, (float)(180 + Mathf.Atan(y / x) * 57.3))); 
        bbullteMove.GetComponent<Rigidbody2D>().AddForce(Vector2.left * x * 200);
        bbullteMove.GetComponent<Rigidbody2D>().AddForce(Vector2.down * y * 200);
        AudioManager.Instance.PlaySound("【麦克雷】午时已到枪声");
        Destroy(bbullteMove, 3f);
        yield return new WaitForSeconds(1);
        as1.volume = 1F;
        ani.SetBool("isQ", false);
      
        yield return new WaitForSeconds(3);
        //右下
        GameObject warn4 = Instantiate(warn, new Vector3(5, -3.59F, 10), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        yield return new WaitForSeconds(0.5F);
        warn4.SetActive(false);
        yield return new WaitForSeconds(0.5F);
        warn4.SetActive(true);
        yield return new WaitForSeconds(0.5F);
        warn4.SetActive(false);
        yield return new WaitForSeconds(0.5F);
        GetComponent<Transform>().position = new Vector3(5, -3.59F, 10);
        yield return new WaitForSeconds(1);
        Fire2();
        Move();
    }
    IEnumerator BossDie()
    {
        Time.timeScale = 0.4F;
        yield return new WaitForSeconds(0.8F);


        icon.SetActive(false);
        hp1.SetActive(false);
        hp2.SetActive(false);
        hp3.SetActive(false);
        hp4.SetActive(false);
        hp5.SetActive(false);
        hp6.SetActive(false);
        j.SetActive(false);
        e.SetActive(false);
        q.SetActive(false);
        jcdi.SetActive(false);
        ecdi.SetActive(false);
        qcdi.SetActive(false);
        as1.Stop();
        AudioManager.Instance.PlaySound("【雅典娜】【系统】胜利");
        GameObject.Find("Fade").GetComponent<FadeControl>().m_Sprite.color = new Color(255, 255, 255, 0);
        GameObject.Find("Fade").GetComponent<FadeControl>().m_Statuss = FadeStatuss.FadeIn;
        yield return new WaitForSeconds(1);
        Time.timeScale = 1;
        SceneManager.LoadScene(5);
    }


    private void Fire()
    {

        
            GameObject bullteMove = Instantiate(Ebullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            float x = GetComponent<Transform>().position.x - Player.transform.position.x;
            float y = GetComponent<Transform>().position.y - Player.transform.position.y;
            bullteMove.GetComponent<Rigidbody2D>().AddForce(Vector2.left * x * 50);
            bullteMove.GetComponent<Rigidbody2D>().AddForce(Vector2.down * y * 50);
            Destroy(bullteMove, 3f);
       
    }
    private void Fire2()
    {


        GameObject bullteMove1 = Instantiate(Ebullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        GameObject bullteMove2 = Instantiate(Ebullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        GameObject bullteMove3 = Instantiate(Ebullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        GameObject bullteMove4 = Instantiate(Ebullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
    

        float x = GetComponent<Transform>().position.x - Player.transform.position.x;
        float y = GetComponent<Transform>().position.y - Player.transform.position.y;
        bullteMove1.GetComponent<Rigidbody2D>().AddForce(Vector2.left * x * 60);
        bullteMove1.GetComponent<Rigidbody2D>().AddForce(Vector2.down * y * 20);
        bullteMove2.GetComponent<Rigidbody2D>().AddForce(Vector2.left * x * 50);
        bullteMove2.GetComponent<Rigidbody2D>().AddForce(Vector2.down * y * 30);
        bullteMove3.GetComponent<Rigidbody2D>().AddForce(Vector2.left * x * 30);
        bullteMove3.GetComponent<Rigidbody2D>().AddForce(Vector2.down * y * 50);
        bullteMove4.GetComponent<Rigidbody2D>().AddForce(Vector2.left * x * 20);
        bullteMove4.GetComponent<Rigidbody2D>().AddForce(Vector2.down * y * 60);
      
        Destroy(bullteMove1, 3f);
        Destroy(bullteMove2, 3f);
        Destroy(bullteMove3, 3f);
        Destroy(bullteMove4, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            Hp -= 1;
            Bosshp[Hp].SetActive(false);
        }
        if (collision.tag == "sword")
        {
            Hp -= 10;
            for(int i = 0; i < 10; i++)
            {
                if(Hp+i>=0)
                Bosshp[Hp+i].SetActive(false);
            }

        }
        if (collision.tag == "playerBBullet")
        {
            Hp -= 20;
            for (int i = 0; i < 20; i++)
            {
                if (Hp + i >= 0)
                Bosshp[Hp + i].SetActive(false);
            }
        }
    }


}
