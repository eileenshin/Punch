using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject standard; //endPos

    public OVRInput.Controller hand;  //양손

    //이펙트공장
    public GameObject eftFactory;
    //반경
    public float eftRange = 2;

    IEnumerator Vibration()
    {
        OVRInput.SetControllerVibration(1f, 1f, hand);

        yield return null;
        OVRInput.SetControllerVibration(0, 0, hand);
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Node")
        {

            ////이펙트
            //GameObject eft = Instantiate(eftFactory);
            //eft.transform.position = transform.position;
            //Destroy(eft, 1);


            ////Endpos(기준) - 손 위치
            //float dist = Mathf.Abs(standard.transform.position.y - other.gameObject.transform.position.y);
            //Destroy(other.gameObject);

            //if (dist > -0.5f && dist < 1f)
            //{
            //    print("Perfect");
            //    ScoreManager.instance.AddScore(100);

            //    //print("득점,");
            //    //ScoreManager.instance.AddScore();
            //    //ScoreManager.instance.score += 100;
            //    //ScoreManager.instance.combo += 1;
            //    //ScoreManager.instance.currHP += 1;
            //}
            //else
            //{
            //    print("Miss");
            //    ScoreManager.instance.score = 0;
            //    ScoreManager.instance.currHP -= 10;
            //    ScoreManager.instance.combo = 0;
            //    ScoreManager.instance.missCount += 1;
            //    //print("Miss");
            //    //ScoreManager.instance.missCount += 1;
            //    //ScoreManager.instance.combo = 0;
            //    //ScoreManager.instance.currHP -= 10;
            //}

            //Dissolve dissolve = other.gameObject.GetComponent<Dissolve>();
            //dissolve.Show();

            //EnmeyFracture fracture = other.gameObject.GetComponent<EnmeyFracture>();
            //fracture.OnHit();

            StartCoroutine(Vibration());

        }
    }

}

