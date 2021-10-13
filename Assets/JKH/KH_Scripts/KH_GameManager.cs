using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
public class KH_GameManager : MonoBehaviour
{
    public static KH_GameManager instance;

    //��ȣ, �ð��� ������ ����Ʈ
    public List<NodeInfo> listNode = new List<NodeInfo>();

    //��� ������ �ϴ� ����
    public GameObject nodeFactory;

    //�뷡 
    public AudioSource bgm;

    //���� �帣�� �ð�
    float currTime;

    //�� ���� �ð�
    public float nextTime = 3f; //5

    //��� ī��Ʈ
    public int nodeCnt = 0;

    public float nodeSpeed;

    //��尡 ���۵Ǵ� ��ǥ 
    public Transform[] nodePos;
    //��尡 ������ ��ǥ
    public Transform endPos;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (KH_BeatMaker.instance.beatMakerMode) return;

        LoadNode();

        //pos�� endpos���� �Ÿ� (����)
        float dist = Mathf.Abs(nodePos[0].position.z - endPos.position.z);
        //ù���� ����Ʈ����� �ð��� �״����ð� ����?? @@�̰� �� �𸣰���
        float gapTime = Mathf.Abs(listNode[0].time - nextTime);

        //�ӵ�= �Ÿ�/�ð�
        nodeSpeed = (dist / gapTime) ; //gaptime
                                                      //�ణ �밡�� 

    }

    private void FixedUpdate()
    {
        //�ξ� BeatMakerMode ��� �Լ����� ���´�.
        if (KH_BeatMaker.instance.beatMakerMode) return;

        currTime += Time.fixedDeltaTime;
        if (currTime > 1.5f)
        {
            //�뷡�� �ѹ��� ����ǰ� �ϱ����� (�����̹ݺ��Ǿ� �뷡�� �ȳ���)
            if (bgm.isPlaying == false)
            {
                bgm.Play();
                currTime = 0; //����ð� �ʱ�ȭ!!!!!!!!!
            }
        }

        if (currTime > nextTime) //5��
        {
            ////5�ʰ� ������ ��尡 �����ȴ�.
            //if (nodeCnt < listNode.Count - 1)
            //{

            //    //�����忡�� ��带 ����
            //    GameObject node = Instantiate(nodeFactory);
            //    //listNode�� n��°���� nodeNum ������ �����´�
            //    int idx = listNode[nodeCnt].nodeNum - 1;
            //    //nodePos(0�� 1��)�� ��ġ��Ų�� 
            //    node.transform.position = nodePos[idx].position;
            //    //nextTime= ���� ���ð�- ������ �ð�
            //    nextTime += (listNode[nodeCnt + 1].time - listNode[nodeCnt].time);
            //    //Node ��ũ��Ʈ�� �����´�.
            //    KH_Node n = node.GetComponent<KH_Node>();
            //    //�� ���� nodeNum�� �����Ѵ�. ??????????
            //    n.nodeNum = listNode[nodeCnt].nodeNum;
            //    //������带 �����ϱ� ���� nodeCnt������Ų��
            //    nodeCnt++;
            //}


            //copied
            if (nodeCnt < listNode.Count) //listNode-1 = nodeNum[0] �� ����� �������� Ŀ����
            {

                GameObject node = Instantiate(nodeFactory);
                int idx = listNode[nodeCnt].nodeNum - 1;
                node.transform.position = nodePos[idx].position;
                //node.transform.SetParent(nodePos[idx]);
                if (nodeCnt < listNode.Count - 1)
                {
                    nextTime += (listNode[nodeCnt + 1].time - listNode[nodeCnt].time);
                }

                KH_Node n = node.GetComponent<KH_Node>();
                n.nodeNum = listNode[nodeCnt].nodeNum;

                nodeCnt++;
            }
        }
    }


    //��� �ҷ����� �ڵ�
    public void LoadNode()
    {
        FileStream file = new FileStream(Application.dataPath + "/Shark.txt", FileMode.Open);
        byte[] byteData = new byte[file.Length];
        file.Read(byteData, 0, byteData.Length);
        file.Close();

        NodeJsonData data = JsonUtility.FromJson<NodeJsonData>(Encoding.UTF8.GetString(byteData));

        for (int i = 0; i < data.data.Count; i++)
        {
            listNode.Add(data.data[i]);
        }
    }
}
