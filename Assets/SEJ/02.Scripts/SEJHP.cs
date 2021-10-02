using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SEJHP : MonoBehaviour
{
    //체력
    public float currHP;
    public float maxHP = 100;
    float percent;

    //HP UI image컴포넌트
    public Image HpBar;
    public Image BackHpBar;
    public Text Hp;

    void Start()
    {
        //현재HP를 max HP로
        currHP = maxHP;
        percent = (float)currHP / (float)maxHP;
    }

    void Update()
    {

        //hp ui의 fillAmount값을 현재HP 값으로
        HpBar.fillAmount = currHP / maxHP;
        Hp.text = currHP + "/" + maxHP;
        percent = (float)currHP / (float)maxHP;

    }

    public void Damaged(float damage)
    {
        print("현재체력 : " + currHP);

        //현재체력을 damage만큼 줄여준다
        currHP -= damage;
        //만약에 현재 HP<=0 이면
        if (currHP <= 0)
        {
         
            
        }

    }



}
