using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Win_Video : MonoBehaviour {

    public VideoPlayer vp;
    //public RenderTexture rt;
	// Use this for initialization
	void Start () {
        //vp = GetComponent<VideoPlayer>();
        //vp.Play();
        StartCoroutine(Wait());
    }
	
	// Update is called once per frame
	void Update () {
        /*if (vp.GetComponent<VideoPlayer>().frame== (long)vp.GetComponent<VideoPlayer>().frameCount)
        {
            SceneManager.LoadScene(6);
        }*/

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(24);
        SceneManager.LoadScene(6);
    }
}
