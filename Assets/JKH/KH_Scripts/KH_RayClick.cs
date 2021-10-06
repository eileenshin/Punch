using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KH_RayClick : MonoBehaviour
{
    //오른손
    public Transform trRight;
    LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //오른손에서 오른손 앞방향으로 나가는 Ray만든다
        Ray ray = new Ray(trRight.position, trRight.forward);
        //만약에 ray를 발사해서 부딪혔다면
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            print(hit.point);
            lr.SetPosition(0, trRight.transform.position);
            lr.SetPosition(1, hit.point);
        }
        else
        {
            lr.SetPosition(0, Vector3.zero);
            lr.SetPosition(1, Vector3.zero);
        }

        //만약 오른쪽  트리거버튼을 누른다면
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            //만약에 부딪힌 놈이 Button이라면 
            Button btn = hit.transform.GetComponent<Button>();
            //Button에 OnClick에 등록된 함수를 실행
            if (btn != null)
            {
                btn.onClick.Invoke();
            }

            if (btn == null)
            {
                return;
            }
        }
    }

    void Ray()
    {

        //lr = line.GetComponent<LineRenderer>();
        //lr.SetPosition(0, trRight.transform.position);
        //lr.SetPosition(1, H);
    }
}
