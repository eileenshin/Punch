using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KH_RayClick : MonoBehaviour
{
    //오른손
    public Transform trRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //만약 오른쪽 A버튼을 누른다면
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            //오른손에서 오른손 앞방향으로 나가는 Ray만든다
            Ray ray = new Ray(trRight.position, trRight.forward);
            //만약에 ray를 발사해서 부딪혔다면
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //만약에 부딪힌 놈이 Button이라면 
                Button btn = hit.transform.GetComponent<Button>();
                //Button에 OnClick에 등록된 함수를 실행
                if (btn != null)
                {
                    btn.onClick.Invoke();
                }
            }

        }
    }
}
