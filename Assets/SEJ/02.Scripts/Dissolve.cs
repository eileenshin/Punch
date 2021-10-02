using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    float dissolvePower = 0;
    MeshRenderer mr;
    bool startDissolve;
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(startDissolve == true)
        {
            mr.material.SetFloat("_Dp", dissolvePower);
            dissolvePower += Time.deltaTime * 5f;
            if (dissolvePower > 1)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Show()
    {
        startDissolve = true;
        SphereCollider col = GetComponent<SphereCollider>();
        col.enabled = false;

        Node node = GetComponent<Node>();
        node.enabled = false;
    }
}
