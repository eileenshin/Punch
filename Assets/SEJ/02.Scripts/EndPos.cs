using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPos : MonoBehaviour
{
    public Transform end1;
    
    public Transform end3;

    void Update()
    {

        //�������� �ȿ� ������
        //1����ư ������ ��
        if (Input.GetKey(KeyCode.Alpha1))
        {
            //end1 �ڸ��� ����


            //��尡 �ı��ȴ�
            end1.gameObject.SetActive(true);
        }
        else
        {
            end1.gameObject.SetActive(false);
        }


        //2����ư ������ ��
        //end2 �ڸ��� ����
        //��尡 �ı��ȴ�

        //if (Input.GetKey(KeyCode.Alpha2))
        //{

        //    end2.gameObject.SetActive(true);

        //}
        //else
        //{
        //    end2.gameObject.SetActive(false);
        //}

        if (Input.GetKey(KeyCode.Alpha3))
        {

            end3.gameObject.SetActive(true);

        }
        else
        {
            end3.gameObject.SetActive(false);
        }


       
    }

}