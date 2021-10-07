using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public float speed = 1;
    public int nodeNum;
    public float currTime;

    GameObject standard; //endPos

    //����Ʈ����
    GameObject eftFactory;
    //�ݰ�
    public float eftRange = 2;


    void Start()
    {
        speed = GameManager.instance.nodeSpeed;
        standard = GameObject.Find("EndPos");
        //����Ʈ�� �Ȱ��� gameobjectã�Ƽ� transform�����ϱ�
        //eftFactory = GameObject.Find("") 
    }

   


    private void FixedUpdate()
    {
      //  if(currTime < 9.36723f)
        {
            //currTime += Time.fixedDeltaTime;

            transform.position += Vector3.back * speed * Time.fixedDeltaTime;
           
        }
    }
      


    bool isTrigger = true;
    private void OnTriggerEnter(Collider other)
    {
        if (!isTrigger) return;
        //�����տ� ������
        if (other.gameObject.tag == "Hand")
        {
            isTrigger = false;
            //����Ʈ
            //GameObject eft = Instantiate(eftFactory);
            //eft.transform.position = transform.position;
            //Destroy(eft, 15);


            //Endpos(����) - �� ��ġ
            float dist = Mathf.Abs(standard.transform.position.y - gameObject.transform.position.y);
            Destroy(gameObject);

            if (dist > -0.5f && dist < 1f)
            {
                print("Perfect");
                ScoreManager.instance.AddScore(100);

                //print("����,");
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

            //StartCoroutine(Vibration());

        }
    }
}

