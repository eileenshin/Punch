using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SEJHP : MonoBehaviour
{
    //체력
    public float currHP;
    public float maxHP = 100;
   
    //HP UI image컴포넌트
    public Image HpBar;
    public Image BackHpBar;
    public Text Hp;

    void Start()
    {
        //현재HP를 max HP로
        currHP = maxHP;
    }

    void Update()
    {

        //hp ui의 fillAmount값을 현재HP 값으로
        HpBar.fillAmount = currHP / maxHP;
    
    }





}
