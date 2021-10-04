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

    //��������ġ
    public Transform trRight;
    ////�ε��� ��ġ
    //Vector3 hitPoint;
    void Update()
    {
        //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {

            Ray ray = new Ray(trRight.position, trRight.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //0:��������ġ , 1: �ε��� ��ġ
                line.SetPosition(0, trRight.position);
                line.SetPosition(1, hit.point);
            }
            else
            {
                line.SetPosition(0, Vector3.zero);
                line.SetPosition(1, Vector3.zero);
            }
        }
        //���࿡ ������ Ʈ���Ź�ư�� ������
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            //��������ġ, ������ �չ������� ������ Ray�����
            Ray ray = new Ray(trRight.position, trRight.forward);
            //���࿡ ray�� �ؼ� ��򰡿� �ε����ٸ�
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //���࿡ �ε��� ���� Button�̶��
                Button btn = hit.transform.GetComponent<Button>();
                if (btn != null)
                {
                    //Button�� OnClick�� ��ϵ� �Լ��� ����
                    btn.onClick.Invoke();
                }
            }
        }
    }

}
