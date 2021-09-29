using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    //���� ������
    enum ScoreM
    {
        perfect, //0
        good,     //1
        bad,      //2
        miss      //3
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    void Start()
    {

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
