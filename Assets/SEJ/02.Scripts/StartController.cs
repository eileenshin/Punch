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
            int layer = 1 << LayerMask.NameToLayer("UI");
            if(Physics.Raycast(ray, out hit))
            {
                line.gameObject.SetActive(true);
                line.SetPosition(0, trRight.position);
                line.SetPosition(1, hit.point);
                //���࿡ �ε��� ���� Button�̶�� 
                Button btn = hit.transform.GetComponent<Button>();
                //Button�� OnClick�� ��ϵ� �Լ��� ����
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
