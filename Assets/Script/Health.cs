using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 处理生命值和伤害
/// </summary>
public class Health: MonoBehaviour
{
    private Animator ani;
    
    #region 1 - 变量

    /// <summary>
    /// 总生命值
    /// </summary>
    public int Hp = 1;

    /// <summary>
    /// 敌人标识
    /// </summary>


    #endregion

    /// <summary>
    /// 对敌人造成伤害并检查对象是否应该被销毁
    /// </summary>
    /// <param name="damageCount"></param>
    /// 
    void Start()
    {
        ani = GetComponent<Animator>();
    }
    public void Damage(int damageCount)
    {
        Hp -= damageCount;
        Debug.Log("Enemy Hp " + Hp);
        if (Hp <= 0)
        {
            // 死亡! 销毁对象!

            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<BoxCollider2D>());
        yield return new WaitForSeconds(0.5F);
        Destroy(gameObject);
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "bullet")
        {
            Damage(1);
            if (ani.GetBool("isInjur") == false)
            {
                AudioManager.Instance.PlaySound("【训练机器人】");
                StartCoroutine(Wait("isInjur", 0.5F, false));
            }
            ani.SetBool("isInjur", true);
            Destroy(collider);


        }
        if (collider.tag == "sword")
        {
            Damage(10);
            if (ani.GetBool("isInjur") == false)
            {
                AudioManager.Instance.PlaySound("【训练机器人】");
                StartCoroutine(Wait("isInjur", 0.5F, false));
            }          
            ani.SetBool("isInjur", true);
            
        }
          
    }

    IEnumerator Wait(string str,float time,bool status)
    {
        yield return new WaitForSeconds(0.5F);
        ani.SetBool(str,status);
        

    }
}
