using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPos : MonoBehaviour
{
    public Transform end1;
    
    public Transform end3;

    void Update()
    {

        //판정범위 안에 들어오면
        //1번버튼 눌렀을 때
        if (Input.GetKey(KeyCode.Alpha1))
        {
            //end1 자리에 닿은


            //노드가 파괴된다
            end1.gameObject.SetActive(true);
        }
        else
        {
            end1.gameObject.SetActive(false);
        }


        //2번버튼 눌렀을 때
        //end2 자리에 닿은
        //노드가 파괴된다

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