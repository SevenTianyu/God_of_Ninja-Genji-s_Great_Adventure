using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance;
    private AudioSource player;
	// Use this for initialization
	void Start () {
        Instance = this;
        player = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        player.volume = GameObject.Find("HpReader").GetComponent<HpReader>().volume;		
	}

    public void PlaySound(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>(name);
        player.PlayOneShot(clip);

    }

    public void StopSound()
    {
        player.Stop();
    }

    public void Volume(float num)
    {
        player.volume = num;
    }
}
