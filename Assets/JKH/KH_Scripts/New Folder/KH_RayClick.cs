using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KH_RayClick : MonoBehaviour
{
    //������
    public Transform trRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���� ������ A��ư�� �����ٸ�
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            //�����տ��� ������ �չ������� ������ Ray�����
            Ray ray = new Ray(trRight.position, trRight.forward);
            //���࿡ ray�� �߻��ؼ� �ε����ٸ�
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
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
    }
}
