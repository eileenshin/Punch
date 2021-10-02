using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{


    //�̱����������� ScoreManager ��´�
    public static ScoreManager instance = null;
    //���� ��ü��  End1���� �����ϸ�
    //��������� ScoreManager�� ���ش�
    //�޺�����, ��������, ����ü��
    public int combo;
    public int score;
    public int bestScore;
    public int Hp;


 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    void Start()
    {
        //����HP
        Hp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp > 100)
        {
            Hp = 100;
        }

    }

    //public �ٸ��������� �� �� �ְ� �ϰڴ�
    public void AddScore(int addValue)
    {

        //������ ������Ʈ�� �������� ���� ������Ű�� 
      score += addValue;


        //���࿡ ���������� �ְ��������� Ŀ����
        if (score > bestScore)
        {
            //�ְ������� ���������� ����
            bestScore = score;

            //�ְ������� �����Ѵ� playerprefs.setint("�̸�",��)
            PlayerPrefs.SetInt("best_score", bestScore);
        }
    }
}
