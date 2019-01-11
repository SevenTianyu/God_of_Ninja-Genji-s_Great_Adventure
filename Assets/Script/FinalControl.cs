using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalControl : MonoBehaviour {

    public GameObject BlackBac;
    private float m_Alpha = 1;
    private FadeStatuss m_Statuss;

    public GameObject FinalPlayer;
    public GameObject FinalBoss;
    private float f_Alpha = 0;
    private FadeStatuss f_Statuss;

    public GameObject dialog1;
    public GameObject dialog2;
    public GameObject playerText1;
    public GameObject playerText2;
    public GameObject bossText1;
    public GameObject bossText2;
    public GameObject bossText3;
    public AudioSource bacas;
    public GameObject SpaceText;
    private int i = 0;
    private int j = 0;
	// Use this for initialization
	void Start () {
        bacas.Stop();
        GameObject.Find("player").GetComponent<playercontrol>().canDo = false;
        GameObject.Find("Boss").GetComponent<BossControlScript>().canDo = false;
        GameObject.Find("Q_Texie").GetComponent<Q_Texie>().canDo = false;
        BlackBac.SetActive(true);
        BlackBac.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        m_Statuss = FadeStatuss.FadeOut;
        //GameObject.Find("player").GetComponent<playercontrol>().canDo = false;
        //GameObject.Find("Boss").GetComponent<BossControlScript>().canDo = false;
        StartCoroutine(WaittoDo());
	}
	
	// Update is called once per frame
	void Update () {
        if (i == 0)
        {
            
            if (m_Statuss == FadeStatuss.FadeIn)
            {
                m_Alpha += 0.2F * Time.deltaTime;
            }
            else if (m_Statuss == FadeStatuss.FadeOut)
            {
                m_Alpha -= 0.2F * Time.deltaTime;
            }
            UpdateColorAlpha(BlackBac,m_Alpha);
            StartCoroutine(Wait());
        }
        if (j == 1)
        {

            if (f_Statuss == FadeStatuss.FadeIn)
            {
                f_Alpha += 0.3F * Time.deltaTime;
            }
            else if (m_Statuss == FadeStatuss.FadeOut)
            {
                f_Alpha -= 0.3F * Time.deltaTime;
            }
            UpdateColorAlpha(FinalBoss,f_Alpha);
            UpdateColorAlpha(FinalPlayer,f_Alpha);
           
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            StopAllCoroutines();
            Last();
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        i = 1;
    }
    IEnumerator WaittoDo()
    {
        yield return new WaitForSeconds(2F);
        j++;
        f_Statuss = FadeStatuss.FadeIn;
        
        yield return new WaitForSeconds(3.3F);
        SpaceText.SetActive(true);
        dialog2.SetActive(true);
        
        yield return new WaitForSeconds(0.5F);
        
        AudioManager.Instance.PlaySound("【麦克雷（新）】你看上去很眼熟，我杀过你吗？");
        char[] s1 = "你看上去很眼熟，我杀过你吗？".ToCharArray();
        string t = "";
        bossText1.SetActive(true);
        for (int k=0;k<s1.Length;k++){
            t = t + s1[k];
            bossText1.GetComponent<Text>().text = t;
            
            yield return new WaitForSeconds(0.1F);
            
        }
        //text1
        
        yield return new WaitForSeconds(2);
        
        bossText1.SetActive(false);
        dialog2.SetActive(false);
        dialog1.SetActive(true);
        
        yield return new WaitForSeconds(0.5F);
        
        AudioManager.Instance.PlaySound("【威尼斯行动】【源氏】【对麦克雷】麦克雷，为什么要对一个人的死耿耿于怀？这不是我们第一次杀人了！ (1)");
        char[] s2 = "麦克雷，为什么要对一个人的死耿耿于怀？这不是我们第一次杀人了！".ToCharArray();
        string t2 = "";
        playerText1.SetActive(true);
        for (int k = 0; k < s2.Length; k++)
        {
            t2 = t2 + s2[k];
            playerText1.GetComponent<Text>().text = t2;
            
            yield return new WaitForSeconds(0.1F);
            
        }
        //text2
        
        yield return new WaitForSeconds(3);
        
        playerText1.SetActive(false);
        dialog1.SetActive(false);
        dialog2.SetActive(true);
        
        yield return new WaitForSeconds(0.5F);
        
        AudioManager.Instance.PlaySound("【威尼斯行动】【麦克雷】【对源氏】源氏，作为一个……半机械人到底是什么感觉");
        char[] s3 = "源氏，作为一个……半机械人到底是什么感觉".ToCharArray();
        string t3 = "";
        bossText2.SetActive(true);
        for (int k = 0; k < s3.Length; k++)
        {
            t3 = t3 + s3[k];
            bossText2.GetComponent<Text>().text = t3;
            
            yield return new WaitForSeconds(0.1F);
            
        }
        //text3
        
        yield return new WaitForSeconds(3);
        
        bossText2.SetActive(false);
        
        yield return new WaitForSeconds(0.5F);
        
        AudioManager.Instance.PlaySound("【威尼斯行动】【麦克雷】【对源氏】我不是针对你，源氏，不过我不会给他们机会改造我的");
        char[] s4 = "我不是针对你，源氏，不过我不会给他们机会改造我的".ToCharArray();
        string t4 = "";
        bossText3.SetActive(true);
        for (int k = 0; k < s4.Length; k++)
        {
            t4 = t4 + s4[k];
            bossText3.GetComponent<Text>().text = t4;
            
            yield return new WaitForSeconds(0.1F);
            
        }

        //text4
        
        yield return new WaitForSeconds(3);
        
        bossText3.SetActive(false);
        dialog2.SetActive(false);
        dialog1.SetActive(true);
        
        yield return new WaitForSeconds(0.5F);
        
        AudioManager.Instance.PlaySound("【源氏】放马过来吧。。");
        char[] s5 = "放马过来吧。。".ToCharArray();
        string t5 = "";
        
        playerText2.SetActive(true);
        
        for (int k = 0; k < s5.Length; k++)
        {
            t5 = t5 + s5[k];
            playerText2.GetComponent<Text>().text = t5;
            
            yield return new WaitForSeconds(0.1F);
            
        }
        //text5
        
        yield return new WaitForSeconds(3);
        SpaceText.SetActive(false);
        playerText2.SetActive(false);
        dialog1.SetActive(false);
    //yield return new WaitForSeconds(2);
  
        FinalBoss.SetActive(false);
        FinalPlayer.SetActive(false);
        m_Statuss = FadeStatuss.FadeOut;
        i = 0;
    
        GameObject.Find("player").GetComponent<playercontrol>().canDo = true;
        GameObject.Find("Boss").GetComponent<BossControlScript>().canDo = true;
        GameObject.Find("Q_Texie").GetComponent<Q_Texie>().canDo = true;

        bacas.Play();
    }

    private void Last()
    {
        dialog1.SetActive(false);
        dialog2.SetActive(false);
        playerText1.SetActive(false);
        playerText2.SetActive(false);
        bossText1.SetActive(false);
        bossText2.SetActive(false);
        bossText3.SetActive(false);
        FinalBoss.SetActive(false);
        FinalPlayer.SetActive(false);
        SpaceText.SetActive(false);
        m_Statuss = FadeStatuss.FadeOut;
        i = 0;

        GameObject.Find("player").GetComponent<playercontrol>().canDo = true;
        GameObject.Find("Boss").GetComponent<BossControlScript>().canDo = true;
        GameObject.Find("Q_Texie").GetComponent<Q_Texie>().canDo = true;

        bacas.Play();
    }

    void UpdateColorAlpha(GameObject img,float m_Alpha)
    {
        Color ss = img.GetComponent<Image>().color;
        ss.a = m_Alpha;
        img.GetComponent<Image>().color = ss;
        if (m_Alpha > 1)
        {
            m_Alpha = 1;
        }
        if (m_Alpha < 0)
        {
            m_Alpha = 0;
        }

    }


}
