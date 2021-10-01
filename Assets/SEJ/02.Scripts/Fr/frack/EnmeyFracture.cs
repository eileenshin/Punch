using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Scripts.Fractures;
using UnityEngine.UI;


public class EnmeyFracture : MonoBehaviour
{
    GameObject fractureObj;


    // Start is called before the first frame update
    void Start()
    {
        fractureObj = FractureThis.GetInstance().CreateFracture(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnHit()
    {
        fractureObj.transform.position = transform.position;
        fractureObj.SetActive(true);
        fractureObj.gameObject.GetComponentInChildren<Rigidbody>().AddExplosionForce(1000, fractureObj.transform.position, 1);

        Destroy(fractureObj, 0.5f);

        Destroy(gameObject);
    }
}
