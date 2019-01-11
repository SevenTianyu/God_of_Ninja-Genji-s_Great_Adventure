using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  当前游戏对象简单的移动行为
/// </summary>
public class MoveScript : MonoBehaviour
{
    #region 1 - 变量

    // private Rigidbody2D enemyRBody;
    public GameObject Player;
    private Vector2 movement;

    #endregion
    public int Hp = 1;


    public GameObject Ebullet;
    private int dir = 1;

    private Animator ani;

    // Use this for initialization
    void Start()
    {
        //enemyRBody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 2 - 保存运动轨迹
        if (Hp <= 0)
        {
            return;
        }
        if (ani.GetBool("isInjur")==false)
        {
            transform.Translate(Vector2.right * dir * 2f * Time.deltaTime);
        }
        




    }
    //子弹
    private void Fire()
    {

        if (!GetComponent<SpriteRenderer>().flipX)
        {
            GameObject bullteMove = Instantiate(Ebullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            if (System.Math.Abs(Player.transform.position.x - GetComponent<Transform>().position.x) < 12)
            {
                AudioManager.Instance.PlaySound("【美】右键攻击");
            }
            
            bullteMove.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 500);
            Destroy(bullteMove, 1f);
        }
        if (GetComponent<SpriteRenderer>().flipX)
        {
            GameObject bullteMove = Instantiate(Ebullet, transform.position, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
            if (System.Math.Abs(Player.transform.position.x - GetComponent<Transform>().position.x) < 12)
            {
                AudioManager.Instance.PlaySound("【美】右键攻击");
            }
            bullteMove.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * 500);
            Destroy(bullteMove, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "enemyArea")
        {
            ani.SetBool("isTrans", true);
            Fire();
            StartCoroutine(WaitAndTrans());
        }
        if (collision.tag == "enemyArea2")
        {
            Fire();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "enemyArea")
        {
            ani.SetBool("isTrans", false);


        }

    }

    IEnumerator WaitAndTrans()
    {

        int a = dir;
        dir = 0;
        yield return new WaitForSeconds(1);
        dir = -a;

        GetComponent<SpriteRenderer>().flipX = dir > 0 ? false : true;
    }






}