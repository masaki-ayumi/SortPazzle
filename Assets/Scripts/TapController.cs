using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
    private bool isTouch;        //オブジェクトを触ったか判定するフラグ
    // Start is called before the first frame update
    void Start()
    {
        isTouch = false;
    }

    // Update is called once per frame
    void Update()
    {
        //関数が動いたら別の関数を動かす
        if (isTouch == true)
        {
            Debug.Log("別の関数");
        }
        isTouch = false;
    }

    public void TapObject()
    {
        isTouch = true;
        //スクリプトをアタッチしたオブジェクトを親オブジェクトとする
        GameObject parent = this.gameObject;

        //親オブジェクトの一つ下の子オブジェクトを取得
        GameObject child = parent.transform.GetChild(0).gameObject;

        //Debug.Log(child);        
        //子オブジェクトから孫オブジェクトを取得
        GameObject mago = child.transform.GetChild(0).gameObject;
        Debug.Log(mago);
    }
}
