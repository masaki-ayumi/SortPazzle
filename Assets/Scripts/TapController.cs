using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
    public bool isTouch;        //オブジェクトを触ったか判定するフラグ

    private GameObject tempObject;


    // Start is called before the first frame update
    void Start()
    {
        isTouch = false;
    }

    // Update is called once per frame
    void Update()
    {
        //関数が動いたら別の関数を動かす
        //if (isTouch == true)
        //{
        //
        //    Debug.Log(tempObject);
        //    //isTouch = false;
        //}
    }

    public void TapObject()
    {
        isTouch = true;

        GameObject parent = null;

        GameObject tapGameobject;
        //マウスでタッチしたオブジェクトを親オブジェクトとする
        if (Input.GetMouseButtonDown(0))
        {
            tapGameobject = null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2D)
            {
                tapGameobject = hit2D.transform.gameObject;
                parent = tapGameobject;
            }
        }

        //スクリプトをアタッチしたオブジェクトを親オブジェクトとする
        //GameObject parent = this.gameObject;

        //親オブジェクトの一つ下の子オブジェクトを取得
        GameObject child = parent.transform.GetChild(0).gameObject;

        //Debug.Log(child);        
        //子オブジェクトから孫オブジェクトを取得
        GameObject mago = child.transform.GetChild(0).gameObject;
        Debug.Log(mago);

        tempObject = mago;

        //メモ　違うスクリプトを作り別のタップ関数を作成してタップを判定するフラグを渡してタップした時だけ動くようにしてみよう

    }


}
