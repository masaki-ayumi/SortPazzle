using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public bool isTouch;        //二回目のタッチを判断するためのフラグ
    TapController tapScript;    //一回目のタッチを受け取るためのスクリプト変数
    // Start is called before the first frame update
    void Start()
    {
        isTouch = false;
        tapScript = this.gameObject.GetComponent<TapController>();
        //isTouch = tapScript.isTouch;
    }

    // Update is called once per frame
    void Update()
    {
        //一回目のisTouchの状態を受け取る
        isTouch = tapScript.isTouch;

        if (isTouch == false)
            tapScript.isTouch = isTouch;
    }

    
}
