using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SEJHP : MonoBehaviour
{
    //ü��
    public float currHP;
    public float maxHP = 100;
   
    //HP UI image������Ʈ
    public Image HpBar;
    public Image BackHpBar;
    public Text Hp;

    void Start()
    {
        //����HP�� max HP��
        currHP = maxHP;
    }

    void Update()
    {

        //hp ui�� fillAmount���� ����HP ������
        HpBar.fillAmount = currHP / maxHP;
    
    }





}
