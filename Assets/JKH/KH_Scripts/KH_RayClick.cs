using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KH_RayClick : MonoBehaviour
{
    //������
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
        //�����տ��� ������ �չ������� ������ Ray�����
        Ray ray = new Ray(trRight.position, trRight.forward);
        //���࿡ ray�� �߻��ؼ� �ε����ٸ�
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

        //���� ������ A��ư�� �����ٸ�
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            //���࿡ �ε��� ���� Button�̶�� 
            Button btn = hit.transform.GetComponent<Button>();
            //Button�� OnClick�� ��ϵ� �Լ��� ����
            if (btn != null)
            {
                btn.onClick.Invoke();
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
