using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KH_Node : MonoBehaviour
{
    float speed = 1;
    public int nodeNum;
    // Start is called before the first frame update
    void Start()
    {
        speed = KH_GameManager.instance.nodeSpeed;
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.back * speed * Time.fixedDeltaTime;
        //transform.back? 이렇게하면 되려나?

    }
}
