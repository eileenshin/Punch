using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 게임매니저를 싱글톤패턴으로 사용

    public List<NodeInfo> listNode = new List<NodeInfo>(); //NodeInfo의 배열을 받는 listNode를 

    public GameObject nodeFactory;//노드 생성할 공장

    public AudioSource bgm; //BGM

    public float currTime; // 현재시간 

    public float nextTime = 5; //다음생성될 시간

    public int nodeCnt = 0; //노드의 개수

    public float nodeSpeed; //노드가 떨어지는 속도

    public Material fractureMat;



    public Transform[] nodePos; //노드가 생성될 위치
    public Transform endPos; //노드가 끝날 위치

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        if (BeatMaker.instance.beatMakerMode) return;

        LoadNode();

        float dist = nodePos[0].position.z - endPos.position.z;
        float gapTime =(listNode[0].time - nextTime);
        print(dist + ", " +gapTime);

        nodeSpeed = (dist / gapTime);

    }

    private void FixedUpdate()
    {
        if (BeatMaker.instance.beatMakerMode) return; //BeatMaker의 녹음모드일때 종료한다

        currTime += Time.fixedDeltaTime;
        if (currTime > 1.5f) // 진행시간이 1.5초보다 커지면
        {
            if (bgm.isPlaying == false) //bgm이 재생되는 중이 아니라면
            {
                bgm.Play(); //bgm시작
                currTime = 0; //현재시간 초기화!!!!!!!!!
            }
        }

        if (currTime > nextTime) // 진행시간이 다음생성시간 보다 커지면
        {
            if (nodeCnt < listNode.Count) //listNode-1 = nodeNum[0] 이 노드의 개수보다 커지면
            {

                GameObject node = Instantiate(nodeFactory);
                int idx = listNode[nodeCnt].nodeNum - 1;
                node.transform.position = nodePos[idx].position;

                if(nodeCnt < listNode.Count -1)
                {
                    nextTime += (listNode[nodeCnt + 1].time - listNode[nodeCnt].time);
                }

                Node n = node.GetComponent<Node>();
                n.nodeNum = listNode[nodeCnt].nodeNum;

                nodeCnt++;
            }
        }
    }


    public void LoadNode()
    {

        FileStream file = new FileStream(Application.dataPath + "/text.txt", FileMode.Open);
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
