using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class KH_SwipeMenu : MonoBehaviour
{
    public GameObject scrollbar; //scrollBar_horizontal
    private float scroll_pos = 0;
    float[] pos;

    public int ii;

    public bool isShark = false;
    public bool isNextLevel = false;

    public static KH_SwipeMenu instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�ڽ��� ��
        pos = new float[transform.childCount]; 
        //�Ÿ�= 1/ (�ڽļ�-1)
        float distance = 1f / (pos.Length - 1f); 
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0)) //��� ��ŧ���� ��ư���� ��ü?
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], .1f);
                }
            }
        }

        
        for (ii = 0; ii < pos.Length; ii++)
        {

            //���������� �������� �ȿ� ������ �� ��ư�� ũ���Ѵ�
            if (scroll_pos < pos[ii] + (distance / 2) && scroll_pos > pos[ii] - (distance / 2))
            {
                //i��° ��ư�� ũ���Ѵ�
                Debug.LogWarning("Current Selected Level" + ii);
                transform.GetChild(ii).localScale = Vector2.Lerp(transform.GetChild(ii).localScale, new Vector2(1.2f, 1.2f), 0.1f);
                //i����, ������ ��ư �۰��Ѵ�
                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != ii)
                    {
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }

                if (ii == 0)
                {
                    print("Shark");
                    //KH_SceneManager.instance.onClickStartBtn();
                    isShark = true;
                    isNextLevel = false;
                }

                if (ii == 1)
                {
                    print("NextLevel");
                    //KH_SceneManager.instance.onClickNextLevel();
                    isShark = false;
                    isNextLevel = true;
                }

                if (ii == 2)
                {
                    print("i=2");
                    isShark = false;
                    isNextLevel = false;
                }

                if (ii == 3)
                {
                    print("i=3");
                    isShark = false;
                    isNextLevel = false;
                }
            }
            
        }

        

    }
}
