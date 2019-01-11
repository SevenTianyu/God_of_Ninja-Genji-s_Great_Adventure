using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control_Sound : MonoBehaviour {

    //private float volume;
    //public AudioSource asound;
    //public Slider sd;
	// Use this for initialization
	void Start () {
        //GameObject.Find("HpReader").GetComponent<HpReader>().volume;
        //gameObject.GetComponent<Slider>().value;
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("HpReader").GetComponent<HpReader>().volume=gameObject.GetComponent<Slider>().value;
    }

    /*public void  Con_sound()
    {
        asound.volume = sd.value;
    }*/
}
