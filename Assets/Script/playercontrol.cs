using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playercontrol : MonoBehaviour
{

    //血量
    public int Hp;
    private AsyncOperation mAsyncOperation;
    public GameObject Bullet;
    public GameObject Sword;
    public GameObject EWall;
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

    public Image jcd;
    public Image ecd;
    public Image qcd;

    private float jcdTime=1F;
    private float ecdTime=5F;
    private float qcdTime=30F;

    private float jcurrentTime;
    private float ecurrentTime;
    private float qcurrentTime;

    private int dieTime = 0;
    //大招特写

    //刚体组件
    private Rigidbody2D rBody;
    //动画组件
    private Animator ani;
    private int isGround;
    private bool canMove = true;
    private bool isInjured;

    private bool canJ=true;
    private bool canE=true;
    private bool canQ=true;

    public bool canDo=true;
    
    void Start()
    {
        GameObject.Find("Fade").GetComponent<FadeControl>().m_Statuss = FadeStatuss.FadeOut;
        Hp = GameObject.Find("HpReader").GetComponent<HpReader>().Hp;
        //Hp = 6;
        rBody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        jcurrentTime = jcdTime;
        ecurrentTime = ecdTime;
        qcurrentTime = qcdTime;
        
        

    }

   
    void Update()
    {


        switch (Hp)
        {
            case 5: hp6.SetActive(false);break;
            case 4: hp6.SetActive(false); hp5.SetActive(false); break;
            case 3: hp6.SetActive(false); hp5.SetActive(false); hp4.SetActive(false); break;
            case 2: hp6.SetActive(false); hp5.SetActive(false); hp4.SetActive(false); hp3.SetActive(false); break;
            case 1: hp6.SetActive(false); hp5.SetActive(false); hp4.SetActive(false); hp3.SetActive(false); hp2.SetActive(false); break;
            case 0: hp6.SetActive(false); hp5.SetActive(false); hp4.SetActive(false); hp3.SetActive(false); hp2.SetActive(false); hp1.SetActive(false); break;
        }


        if (canDo)
        {
            float horizontal = Input.GetAxis("Horizontal");
            if (GetComponent<Transform>().position.x > 82.5)
            {
                canMove = false;

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
                GameObject.Find("Fade").GetComponent<FadeControl>().m_Statuss = FadeStatuss.FadeIn;
                StartCoroutine(Load());


            }
            if (Hp == 0)
            {
                ani.SetBool("isDie", true);
                AudioManager.Instance.PlaySound("【源氏】（阵亡）");

                if (horizontal >= 0)
                {

                    rBody.velocity = new Vector2(-4, 8);
                }
                if (horizontal < 0)
                {
                    rBody.velocity = new Vector2(4, 8);
                }
                Destroy(GetComponent<CapsuleCollider2D>());
                Destroy(GetComponent<BoxCollider2D>());
                Destroy(GetComponent<CircleCollider2D>());
                if (GameObject.Find("bossText") != null)
                    Destroy(GameObject.Find("bossText"));


                Hp = Hp - 1;
                return;
            }

            if (Hp < 0 && dieTime == 0)
            {
                dieTime = 1;
                StartCoroutine(PlayerDie());
                return;
            }
            //移动
            //水平轴

            if (horizontal != 0 && canMove && !isInjured)
            {
                //移动
                Vector2 v = rBody.velocity;
                v.x = horizontal * 10;
                rBody.velocity = v;
                //转向
                GetComponent<SpriteRenderer>().flipX = horizontal > 0 ? false : true;
                ani.SetBool("isRun", true);
            }
            else
            {
                //停止
                ani.SetBool("isRun", false);

            }
            //跳跃
            if (Input.GetKeyDown(KeyCode.K) && isGround != 2 && !isInjured)
            {
                //给一个向上的力
                if (isGround == 0)
                    rBody.AddForce(Vector2.up * 600);
                if (isGround == 1)
                {
                    AudioManager.Instance.PlaySound("2");
                    rBody.velocity = new Vector2(rBody.velocity.x, 0);
                    rBody.AddForce(Vector2.up * 600);
                }
                isGround++;
                //播放跳跃声音

            }
            if (Input.GetKeyDown(KeyCode.Q) && canQ)
            {

                ani.SetBool("isQ", true);
                qcurrentTime = 0;
                qcd.fillAmount = 1;
                canQ = false;
                StartCoroutine(WaitSkillQ());
                AudioManager.Instance.PlaySound("【邪鬼】【源氏】（邪鬼皮肤 斩）鬼の剣を喰らえ！（尝尝我的邪鬼之剑！）");
                StartCoroutine(WaitandQ());
                //大招过场
                //大招音效
            }

            if (Input.GetKeyDown(KeyCode.J) && canJ)
            {
                ani.SetTrigger("isAttack");
                jcurrentTime = 0;
                jcd.fillAmount = 1;
                canJ = false;
                StartCoroutine(WaitSkillJ());
                if (ani.GetBool("isQ") == false)
                {

                    AudioManager.Instance.PlaySound("attack");
                    StartCoroutine(Fire3());

                }
                if (ani.GetBool("isQ") == true)
                {
                    StartCoroutine(CutSound());


                }//状态判定
                 //镖的声音
                 //子弹的射出
                 //刀的声音
                 //刀攻击判定
            }
            if (Input.GetKeyDown(KeyCode.E) && canE)
            {
                ani.SetTrigger("isE");
                ecurrentTime = 0;
                ecd.fillAmount = 1;
                canE = false;
                StartCoroutine(WaitSkillE());
                E();
                AudioManager.Instance.PlaySound("e");
                StartCoroutine(Stop());
                //e的声音
                //e的判定
            }

            //cd控制
            if (jcurrentTime < jcdTime)
            {
                jcurrentTime += Time.deltaTime;
                jcd.fillAmount = 1 - jcurrentTime / jcdTime;
            }
            if (ecurrentTime < ecdTime)
            {
                ecurrentTime += Time.deltaTime;
                ecd.fillAmount = 1 - ecurrentTime / ecdTime;
            }
            if (qcurrentTime < qcdTime)
            {
                qcurrentTime += Time.deltaTime;
                qcd.fillAmount = 1 - qcurrentTime / qcdTime;
            }
        }

        
    }
    IEnumerator Load()
    {
        yield return new WaitForSeconds(1.5F);
        SceneManager.LoadScene(3);
    }

    IEnumerator CutSound()
    {
        yield return new WaitForSeconds(0.5F);
        AudioManager.Instance.PlaySound("q_attack");
        Cut();
    }

    IEnumerator Fire3()
    {
        Fire();
        yield return new WaitForSeconds(0.2F);
        Fire();
        yield return new WaitForSeconds(0.2F);
        Fire();
    }

    IEnumerator WaitandQ()
    {
        Time.timeScale = 0.1F;
        yield return new WaitForSeconds(0.15F);
        Time.timeScale = 1;

    }

    IEnumerator Stop()
    {
        canMove = false;
        canJ = false;
        rBody.velocity = new Vector2(0, 0);

        yield return new WaitForSeconds(1.5F);
        canMove = true;
        canJ = true;
    }

    IEnumerator PlayerDie()
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
        GameObject.Find("Fade").GetComponent<FadeControl>().m_Sprite.color = new Color(255, 255, 255,0);
        GameObject.Find("Fade").GetComponent<FadeControl>().m_Statuss = FadeStatuss.FadeIn;
        
        yield return new WaitForSeconds(1);
        Time.timeScale = 1;
        SceneManager.LoadScene(4);
     }

    IEnumerator WaitSkillJ()
    {      
        yield return new WaitForSeconds(jcdTime);
        
        canJ = true;
    }
    IEnumerator WaitSkillE()
    {
   
        yield return new WaitForSeconds(ecdTime);

        canE = true;

    }
    IEnumerator WaitSkillQ()
    {
      
        yield return new WaitForSeconds(10);
        ani.SetBool("isQ", false);
        AudioManager.Instance.PlaySound("【源氏】（“闪”收刀）");

        yield return new WaitForSeconds(qcdTime - 10);

        canQ = true;

    }


    private void E()
    {
        if (!GetComponent<SpriteRenderer>().flipX)
        {
            GameObject eWall = Instantiate(EWall, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;

            Destroy(eWall, 2f);
        }
        if (GetComponent<SpriteRenderer>().flipX)
        {
            GameObject eWall = Instantiate(EWall, transform.position, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;

            Destroy(eWall, 2f);
        }
    }

    private void Cut()
    {
        if (!GetComponent<SpriteRenderer>().flipX)
        {
            GameObject sword = Instantiate(Sword, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            sword.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            Destroy(sword, 1f);
        }
        if (GetComponent<SpriteRenderer>().flipX)
        {
            GameObject sword = Instantiate(Sword, transform.position, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
            sword.GetComponent<Rigidbody2D>().AddForce(Vector2.right * -200);
            Destroy(sword, 1f);
        }
    }

    private void Fire()
    {

        if (!GetComponent<SpriteRenderer>().flipX)
        {
            GameObject bullteMove = Instantiate(Bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            bullteMove.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 1000);
           
            Destroy(bullteMove, 1f);
        }
        if (GetComponent<SpriteRenderer>().flipX)
        {
            GameObject bullteMove = Instantiate(Bullet, transform.position, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
            bullteMove.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * 1000);
           
            Destroy(bullteMove, 1f);
        }
    }

    

    //进入触发，踩了东西
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //如果踩到的是地面

        if (collision.tag == "ground")
        {
            isGround = 0;
            ani.SetBool("isJump", false);
        }
        if (collision.tag == "ground" && isInjured)
        {
            isInjured = false;
            ani.SetBool("isInjured", false);
        }
        if (collision.tag == "wall")
        {
            canMove = false;



        }
        if (collision.tag == "Ebullet" && !isInjured)
        {
            Hp = Hp - 1;
            GameObject.Find("HpReader").GetComponent<HpReader>().Hp = Hp;
            AudioManager.Instance.PlaySound("【源氏】（受到枪击）");
           
            isInjured = true;
            ani.SetBool("isInjured", true);
            float a = GetComponent<Transform>().position.x - collision.transform.position.x;


            if (a < 0)
            {

                rBody.velocity = new Vector2(-4, 8);
            }
            if (a > 0)
            {
                rBody.velocity = new Vector2(4, 8);
            }
        }
        if (collision.tag == "BBullet" && !isInjured)
        {
            Hp = 0;
            GameObject.Find("HpReader").GetComponent<HpReader>().Hp = Hp;

            AudioManager.Instance.PlaySound("【源氏】（受到枪击）");
            AudioManager.Instance.PlaySound("【法老之鹰】（火箭在极远处爆炸）");
            isInjured = true;
            ani.SetBool("isInjured", true);
            float a = GetComponent<Transform>().position.x - collision.transform.position.x;


            if (a < 0)
            {

                rBody.velocity = new Vector2(-4, 8);
            }
            if (a > 0)
            {
                rBody.velocity = new Vector2(4, 8);
            }
        }
    }
    //离开触发，离开东西
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {
           
            ani.SetBool("isJump", true);
        }
        
        if (collision.tag == "wall")
        {
            canMove = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "enemy")
        {
            Hp = Hp - 1;
            GameObject.Find("HpReader").GetComponent<HpReader>().Hp = Hp;
            AudioManager.Instance.PlaySound("【源氏】（受到枪击）");
            
            isInjured = true;
            ani.SetBool("isInjured", true);

            float horizontal = Input.GetAxis("Horizontal");

            if (horizontal >= 0)
            {

                rBody.velocity = new Vector2(-4, 8);
            }
            if (horizontal < 0)
            {
                rBody.velocity = new Vector2(4, 8);
                
            }
        }
    }
}
