using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // ���ӸŴ����� �̱����������� ���

    public List<NodeInfo> listNode = new List<NodeInfo>(); //NodeInfo�� �迭�� �޴� listNode�� 

    public GameObject nodeFactory;//��� ������ ����

    public AudioSource bgm; //BGM

    public float currTime; // ����ð� 

    public float nextTime = 5; //���������� �ð�

    public int nodeCnt = 0; //����� ����

    public float nodeSpeed; //��尡 �������� �ӵ�

    public Material fractureMat;

    public string songName;

    public Transform[] nodePos; //��尡 ������ ��ġ
    public Transform endPos; //��尡 ���� ��ġ

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    /*
     * /text.txt �ؽ�Ʈ����
     * /HMtext.txt ���̸���
     * /onepiece.txt ���ǽ�
     */

    void Start()
    {
        if (BeatMaker.instance.beatMakerMode) return;

        //if(��ũ��Ʈ.instance.bool== true)
        //{
        //  
        //}
        // LoadNode();

        LoadNode(songName);

        //LoadNode("text");
        //LoadNode("HMtext");


        float dist = nodePos[0].position.z - endPos.position.z;
        float gapTime = (listNode[0].time - nextTime);
        print(dist + ", " + gapTime);

        nodeSpeed = (dist / gapTime);

        ScoreManager.instance.Init();
    }


    private void FixedUpdate()
    {
        if (BeatMaker.instance.beatMakerMode) return; //BeatMaker�� ��������϶� �����Ѵ�

        currTime += Time.fixedDeltaTime;
        if (currTime > 1.5f) // ����ð��� 1.5�ʺ��� Ŀ����
        {
            if (bgm.isPlaying == false) //bgm�� ����Ǵ� ���� �ƴ϶��
            {
                bgm.Play(); //bgm����
                currTime = 0; //����ð� �ʱ�ȭ!!!!!!!!!
            }
        }

        if (currTime > nextTime) // ����ð��� ���������ð� ���� Ŀ����
        {
            if (nodeCnt < listNode.Count) //listNode-1 = nodeNum[0] �� ����� �������� Ŀ����
            {

                GameObject node = Instantiate(nodeFactory);
                int idx = listNode[nodeCnt].nodeNum - 1;
                node.transform.position = nodePos[idx].position;

                if (nodeCnt < listNode.Count - 1)
                {
                    nextTime += (listNode[nodeCnt + 1].time - listNode[nodeCnt].time);
                }

                Node n = node.GetComponent<Node>();
                n.nodeNum = listNode[nodeCnt].nodeNum;

                nodeCnt++;
            }
        }
    }



    public void LoadNode(string filename)
    {
    
        //FileStream file = new FileStream(Application.dataPath + "/" + filename + ".txt", FileMode.Open);
        FileStream file = new FileStream("C:/Users/user/Desktop/1015/"+ filename+".txt", FileMode.Open);
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
