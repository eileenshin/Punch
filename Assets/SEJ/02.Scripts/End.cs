using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject standard;

    public OVRInput.Controller hand;

    //����Ʈ����
    public GameObject eftFactory;
    //�ݰ�
    public float eftRange = 2;

    //�������Ʈ ��ġ
    public Transform eftPos;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Vibration()
    {
        OVRInput.SetControllerVibration(1f, 1f, hand);
       
        yield return null;
        OVRInput.SetControllerVibration( 0, 0 , hand);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Node")
        {
            GameObject eft = Instantiate(eftFactory);
            eft.transform.position = transform.position;
            Destroy(eft, 15);


            //Endpos(����) - �� ��ġ
            float dist = Mathf.Abs(standard.transform.position.y - other.gameObject.transform.position.y);

            if (dist > -0.5f && dist < 1f)
            {
                print("Perfect");
                ScoreManager.instance.score += 100;
                ScoreManager.instance.combo += 1;
                ScoreManager.instance.Hp += 1;
   
            }

            else
            {
                print("Miss");

                ScoreManager.instance.combo = 0;
                ScoreManager.instance.Hp -= 10;

            }

            print("Node1 �浹");
            //Destroy(other.gameObject);
            Dissolve dissolve = other.gameObject.GetComponent<Dissolve>();
            dissolve.Show();

            StartCoroutine(Vibration());
           
        }

    }
}
