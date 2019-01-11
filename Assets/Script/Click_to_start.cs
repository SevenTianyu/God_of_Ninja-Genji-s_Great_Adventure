using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click_to_start : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnClick()
    {
        AudioManager.Instance.PlaySound("点击1");

        GameObject.Find("Fade").GetComponent<FadeControl>().m_Statuss = FadeStatuss.FadeIn;
        StartCoroutine(Load());
       
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
