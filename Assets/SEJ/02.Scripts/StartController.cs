using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
   
    public LineRenderer line;
    public Transform trRight;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RHand))
        {
            Ray ray = new Ray(trRight.position, trRight.forward);
            RaycastHit hit;
    
            if(Physics.Raycast(ray, out hit))
            {
                line.gameObject.SetActive(true);
                line.SetPosition(0, trRight.position);
                line.SetPosition(1, hit.point);
                //만약에 부딪힌 놈이 Button이라면 
                Button btn = hit.transform.GetComponent<Button>();
                //Button에 OnClick에 등록된 함수를 실행
                if (btn != null)
                {
                    btn.onClick.Invoke();
                }
            }
            else
            {
                line.gameObject.SetActive(false);
            }

        }
        if(OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RHand))
        {
            if(line.gameObject.activeSelf)
            {
                line.gameObject.SetActive(false);

            }
        }

          




    }
}
