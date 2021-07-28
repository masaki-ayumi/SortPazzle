using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TapObject()
    {
        //Debug.Log("触った");
        parent = transform.Find("DANGOPosition").gameObject;
        GameObject child = parent.transform.GetChild(0).gameObject;
        Debug.Log(child);
        
    }
}
