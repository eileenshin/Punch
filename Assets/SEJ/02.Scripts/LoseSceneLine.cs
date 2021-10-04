using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseSceneLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }


    public LineRenderer line;

    //오른손위치
    public Transform trRight;
    ////부딪힌 위치
    //Vector3 hitPoint;
    void Update()
    {
        //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {

            Ray ray = new Ray(trRight.position, trRight.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //0:오른손위치 , 1: 부딪힌 위치
                line.SetPosition(0, trRight.position);
                line.SetPosition(1, hit.point);
            }
            else
            {
                line.SetPosition(0, Vector3.zero);
                line.SetPosition(1, Vector3.zero);
            }
        }
        //만약에 오른쪽 트리거버튼을 누르면
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            //오른손위치, 오른손 앞방향으로 나가는 Ray만든다
            Ray ray = new Ray(trRight.position, trRight.forward);
            //만약에 ray를 해서 어딘가에 부딪혔다면
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //만약에 부딪힌 놈이 Button이라면
                Button btn = hit.transform.GetComponent<Button>();
                if (btn != null)
                {
                    //Button에 OnClick에 등록된 함수를 실행
                    btn.onClick.Invoke();
                }
            }
        }
    }

}

