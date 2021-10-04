using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject standard; //endPos

    public OVRInput.Controller hand; 

    //이펙트공장
    public GameObject eftFactory;
    //반경
    public float eftRange = 2;

    //노드이펙트 위치
    public Transform eftPos;

    IEnumerator Vibration()
    {
        OVRInput.SetControllerVibration(1f, 1f, hand);
       
        yield return null;
        OVRInput.SetControllerVibration( 0, 0 , hand);
    }

   public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Node")
        {
            GameObject eft = Instantiate(eftFactory);
            eft.transform.position = transform.position;
            Destroy(eft, 15);


            //Endpos(기준) - 손 위치
            float dist = Mathf.Abs(standard.transform.position.y - other.gameObject.transform.position.y);

            if (dist > -0.5f && dist < 1f)
            {
                print("득점,");

                ScoreManager.instance.score += 100;
                ScoreManager.instance.combo += 1;
                ScoreManager.instance.currHP += 1;
            }

            else
            {
                print("Miss");
                ScoreManager.instance.missCount += 1;
                ScoreManager.instance.combo = 0;
                ScoreManager.instance.currHP -= 10;

            }

            print("Node1 충돌");
            Destroy(other.gameObject);
            Dissolve dissolve = other.gameObject.GetComponent<Dissolve>();
            dissolve.Show();

            //EnmeyFracture fracture = other.gameObject.GetComponent<EnmeyFracture>();
            //fracture.OnHit();

            StartCoroutine(Vibration());
          
        }

    }
}
