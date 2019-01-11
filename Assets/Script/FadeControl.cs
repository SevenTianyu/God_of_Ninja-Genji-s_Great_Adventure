using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FadeStatuss
{
    FadeIn,
    FadeOut
}

public class FadeControl : MonoBehaviour {

    public Image m_Sprite;
    private float m_Alpha=1;
    public FadeStatuss m_Statuss;
    public float m_UpdateTime;


	void Start () {
        //DontDestroyOnLoad(gameObject);
        
	}
	
	// Update is called once per frame
	void Update () {
        if (m_Statuss == FadeStatuss.FadeIn)
        {
            m_Alpha += m_UpdateTime * Time.deltaTime;
        }
        else if (m_Statuss == FadeStatuss.FadeOut)
        {
            m_Alpha -= m_UpdateTime * Time.deltaTime;
        }
        UpdateColorAlpha();
    }

    void UpdateColorAlpha()
    {
        Color ss = m_Sprite.color;
        ss.a = m_Alpha;
        m_Sprite.color = ss;
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
