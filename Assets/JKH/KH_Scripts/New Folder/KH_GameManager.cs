using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
public class KH_GameManager : MonoBehaviour
{
    public static KH_GameManager instance;

    //번호, 시간을 저장할 리스트
    public List<NodeInfo> listNode = new List<NodeInfo>();

    //노드 나오게 하는 공장
    public GameObject nodeFactory;

    //노래 
    public AudioSource bgm;

    //현재 흐르는 시간
    float currTime;

    //그 다음 시간
    public float nextTime = 3f; //5

    //노드 카운트
    int nodeCnt = 0;

    public float nodeSpeed;

    //노드가 시작되는 좌표 
    public Transform[] nodePos;
    //노드가 끝나는 좌표
    public Transform endPos;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (KH_BeatMaker.instance.beatMakerMode) return;

        LoadNode();

        //pos와 endpos간의 거리 (절댓값)
        float dist = Mathf.Abs(nodePos[0].position.y - endPos.position.y);
        //첫번쨰 리스트노드의 시간과 그다음시간 차이?? @@이거 잘 모르겠음
        float gapTime = Mathf.Abs(listNode[0].time - nextTime);

        //속도= 거리/시간
        nodeSpeed = (dist / 1) * Time.fixedDeltaTime; //gaptime
                                                      //약간 노가다 

    }

    private void FixedUpdate()
    {
        //민액 BeatMakerMode 라면 함수에서 나온다.
        if (KH_BeatMaker.instance.beatMakerMode) return;

        currTime += Time.fixedDeltaTime;
        if (currTime > 1.5f)
        {
            //노래가 한번만 실행되게 하기위해 (실행이반복되어 노래가 안나옴)
            if (bgm.isPlaying == false)
            {
                bgm.Play();
            }
        }

        if (currTime > nextTime) //5초
        {
            //5초가 지나면 노드가 생성된다.
            if (nodeCnt < listNode.Count - 1)
            {

                //노드공장에서 노드를 생성
                GameObject node = Instantiate(nodeFactory);
                //listNode의 n번째에서 nodeNum 정보를 가져온다
                int idx = listNode[nodeCnt].nodeNum - 1;
                //nodePos(0과 1중)을 위치시킨다 
                node.transform.position = nodePos[idx].position;
                //nextTime= 다음 노드시간- 현재노드 시간
                nextTime += (listNode[nodeCnt + 1].time - listNode[nodeCnt].time);
                //Node 스크립트를 가져온다.
                KH_Node n = node.GetComponent<KH_Node>();
                //그 다음 nodeNum을 저장한다. ??????????
                n.nodeNum = listNode[nodeCnt].nodeNum;
                //다음노드를 생성하기 위핸 nodeCnt증가시킨다
                nodeCnt++;
            }
        }
    }


    //노드 불러내는 코드
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
