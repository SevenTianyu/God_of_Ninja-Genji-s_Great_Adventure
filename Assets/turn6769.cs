using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class turn6769 : MonoBehaviour
{
    // Use this for initialization

    void Start()
    {
        GameObject.Find("Fade").GetComponent<FadeControl>().m_Statuss = FadeStatuss.FadeOut;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void turn5755()
    {

        GameObject.Find("Fade").GetComponent<FadeControl>().m_Sprite.color = new Color(0, 0, 0);
        GameObject.Find("HpReader").GetComponent<HpReader>().Hp = 6;
        SceneManager.LoadScene(1);

    }
    

}

