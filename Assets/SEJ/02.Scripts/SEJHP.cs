using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SEJHP : MonoBehaviour
{
    //ü��
    public float currHP;
    public float maxHP = 100;
    float percent;

    //HP UI image������Ʈ
    public Image HpBar;
    public Image BackHpBar;
    public Text Hp;

    void Start()
    {
        //����HP�� max HP��
        currHP = maxHP;
        percent = (float)currHP / (float)maxHP;
    }

    void Update()
    {

        //hp ui�� fillAmount���� ����HP ������
        HpBar.fillAmount = currHP / maxHP;
        Hp.text = currHP + "/" + maxHP;
        percent = (float)currHP / (float)maxHP;

    }

    public void Damaged(float damage)
    {
        print("����ü�� : " + currHP);

        //����ü���� damage��ŭ �ٿ��ش�
        currHP -= damage;
        //���࿡ ���� HP<=0 �̸�
        if (currHP <= 0)
        {
         
            
        }

    }



}
