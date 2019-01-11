using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPause : MonoBehaviour
{

    //the ButtonPauseMenu
    public GameObject ingameMenu;
    public GameObject BlackBac;

    public void OnPause()//点击“暂停”时执行此方法
    {
        Time.timeScale = 0;
        BlackBac.SetActive(true);
        ingameMenu.SetActive(true);
    }

    public void OnResume()//点击“回到游戏”时执行此方法
    {
        Time.timeScale = 1f;
        ingameMenu.SetActive(false);
        BlackBac.SetActive(false);
    }

    public void OnRestart()//点击“重新开始”时执行此方法
    {
        //Loading Scene0
        GameObject.Find("HpReader").GetComponent<HpReader>().Hp = 6;
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    public void OnBack()
    {
        GameObject.Find("HpReader").GetComponent<HpReader>().Hp = 6;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    void Start()
    {
        BlackBac.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnPause();
        }
        
    }
}
