using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Checkpoint : MonoBehaviour {

    //private UISprite select_front_sprite_6, select_front_sprite_H , select_back_sprite_6,select_back_sprite_H;
    private UISprite select_back, select_front_66, select_front_H;
    private void Awake()
    {
        select_back = this.transform.parent.GetComponent<UISprite>();
    }

    void OnClick()
    {
        string check_name = this.gameObject.name;
        select_back.spriteName = check_name;
    }
}
