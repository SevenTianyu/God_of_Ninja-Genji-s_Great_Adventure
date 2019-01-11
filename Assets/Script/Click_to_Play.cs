using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click_to_Play : MonoBehaviour {
    public GameObject Text;
    
    // Use this for initialization
    void Start () {
        GameObject.Find("Fade").GetComponent<FadeControl>().m_Statuss = FadeStatuss.FadeOut;
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void OnClick()
    {
        AudioManager.Instance.StopSound();
        Text.SetActive(false);
        AudioManager.Instance.PlaySound("点击2");
      
        StartCoroutine(Load());
        
    }
    IEnumerator Load()
    {
        GameObject.Find("Fade").GetComponent<FadeControl>().m_Statuss = FadeStatuss.FadeIn;
        GameObject.Find("Fade").GetComponent<FadeControl>().m_UpdateTime = 1F/2.5F;
        yield return new WaitForSeconds(0.5F);
        AudioManager.Instance.PlaySound("【系统】正在前往66号公路 (1)");
        GameObject.Find("Fade").GetComponent<FadeControl>().m_UpdateTime = 1;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
        

    }

}
