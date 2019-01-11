using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void  OnClick()
    {
       // Debug.Log("123");
        Application.Quit();
    }
}
