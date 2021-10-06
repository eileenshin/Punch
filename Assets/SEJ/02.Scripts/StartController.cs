using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
    public OVRInput.Controller hand;
    public LineRenderer line;
    public Transform trRight;
    public Transform trLeft;

    IEnumerator Vibration()
    {
        OVRInput.SetControllerVibration(1f, 1f, hand);

        yield return null;
        OVRInput.SetControllerVibration(0, 0, hand);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, hand))
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
            StartCoroutine(Vibration());
        }
        if(OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, hand))
        {
            if(line.gameObject.activeSelf)
            {
                line.gameObject.SetActive(false);

            }
        }

          




    }
}
