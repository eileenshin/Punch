using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

[System.Serializable]
public class NodeInfo
{
    //노드 순서 지정
    public int nodeNum;
    //노드가 나올 시간
    public float time;

}
[System.Serializable]
public class NodeJsonData
{
    //데이터를 담을 리스트
    public List<NodeInfo> data;

}

public class BeatMaker : MonoBehaviour
{
    //싱글톤 패턴으로 사용
    public static BeatMaker instance;
    //녹음시작모드
    public bool beatMakerMode;
    //녹음시작중지상태
    bool isRecording;
    //배경음
    public AudioSource bgm;
    //현재시간
    float currTime;

    public List<NodeInfo> listNode = new List<NodeInfo>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        //녹음시작모드일 때 
        if(beatMakerMode == true)
        {
           if(Input.GetMouseButtonDown(0))
            {
                if(isRecording == false)
                {
                    isRecording = true;
                    bgm.Play();

                }
                else //녹음중이었다면
                {
                    isRecording = false;
                    bgm.Stop();
                    SaveNode();
                }
            }
           if(isRecording && bgm.isPlaying) //녹음중이라면 
            {
                currTime += Time.deltaTime;

                //녹음 단축키
                if(Input.GetKeyDown(KeyCode.Alpha1))
                {
                    AddNode(1, currTime);
                }
                if (Input.GetKeyDown(KeyCode.Alpha2)) 
                {
                    AddNode(2, currTime);
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    AddNode(3, currTime);
                }
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    AddNode(4, currTime);
                }
            } 
        }
    
    }
    private void AddNode(int nodeNum, float time)
    {
        NodeInfo info = new NodeInfo();
        info.nodeNum = nodeNum;
        info.time = bgm.time;
        listNode.Add(info);
        print(time + ", " + bgm.time);
    }

    private void SaveNode()
    {
        NodeJsonData data = new NodeJsonData();
        data.data = listNode;
        string str = JsonUtility.ToJson(data, true);

        FileStream file = new FileStream(Application.dataPath + "/text.txt", FileMode.Create);
        byte[] byteData = Encoding.UTF8.GetBytes(str);
        file.Write(byteData, 0, byteData.Length);
        file.Close();
    }
}
                
                
                
                

