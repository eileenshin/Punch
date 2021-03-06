using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public float speed = 1;
    public int nodeNum;
    public float currTime;

    GameObject standard; //endPos

    //이펙트공장
    public GameObject eftFactory;
    //반경
    public float eftRange = 2;


    void Start()
    {
        speed = GameManager.instance.nodeSpeed;
        standard = GameObject.Find("EndPos");
        //이펙트도 똑같이 gameobject찾아서 transform지정하기
        //eftFactory = GameObject.Find("Particle attractor 003 lightning");
    }

   


    private void FixedUpdate()
    {
      //  if(currTime < 9.36723f)
        {
            //currTime += Time.fixedDeltaTime;

            transform.position += Vector3.back * speed * Time.fixedDeltaTime;
           
        }
    }
      

    //노드에 bool값을 넣어서 양손이 닿았을 때 점수의 중복처리를 방지해주자
    bool isTrigger = true;
    
    private void OnTriggerEnter(Collider other)
    {
        //만약 isTrigger가 false
        if (!isTrigger) return; 
        
        //오른손에 닿으면
        if (other.gameObject.tag == "Hand")
        {
            isTrigger = false;


            // 이펙트
            GameObject eft = Instantiate(eftFactory);
            eft.transform.position = other.gameObject.transform.position;
            Destroy(eft, 0.7f);


            //Endpos(기준) - 손 위치
            float dist = Mathf.Abs(standard.transform.position.y - gameObject.transform.position.y);
            Destroy(gameObject);

            if (dist > -0.5f && dist < 1f)
            {
                print("Perfect");
                ScoreManager.instance.AddScore(100);

                //print("득점,");
                //ScoreManager.instance.AddScore();
                //ScoreManager.instance.score += 100;
                //ScoreManager.instance.combo += 1;
                //ScoreManager.instance.currHP += 1;
            }

            else
            {
                print("Miss");
                ScoreManager.instance.score = 0;
                ScoreManager.instance.currHP -= 10;
                ScoreManager.instance.combo = 0;
                ScoreManager.instance.missCount += 1;
                //print("Miss");
                //ScoreManager.instance.missCount += 1;
                //ScoreManager.instance.combo = 0;
                //ScoreManager.instance.currHP -= 10;
            }




            //Dissolve dissolve = other.gameObject.GetComponent<Dissolve>();
            //dissolve.Show();

            //EnmeyFracture fracture = other.gameObject.GetComponent<EnmeyFracture>();
            //fracture.OnHit();

        }
    }
}

