using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
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
        //スクリプトをアタッチしたオブジェクトを親オブジェクトとする
        GameObject parent = this.gameObject;

        //親オブジェクトの一つ下の子オブジェクトを取得
        GameObject child = parent.transform.GetChild(0).gameObject;

        Debug.Log(child);        

        GameObject mago = child.transform.GetChild(0).gameObject;
        Debug.Log(mago);
    }
}
