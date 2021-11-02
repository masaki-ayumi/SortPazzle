using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{

    private GameObject tempObject1;
    private GameObject tempObject2;
    GameObject child = null;
    GameObject mago = null;
    public float count;

    Clear clearScript;
    public GameObject clearscriptObject;

    

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        clearScript = clearscriptObject.GetComponent<Clear>();
    }

    // Update is called once per frame
    void Update()
    {
        //1と2を繰り返す
        if (count >= 3)
        {
            count = 0;
        }


        //オブジェクトの中身があったら入れ替え実行
        if (tempObject1 != null && tempObject2 != null)
        {

            Transform temp;
            Vector3 Vtemp;
            //親オブジェクト入れ替え部分
            temp = tempObject1.transform.parent;
            Vtemp = tempObject1.transform.position;

            tempObject1.transform.parent = tempObject2.transform.parent;
            tempObject1.transform.position = tempObject2.transform.position;

            tempObject2.transform.parent = temp;
            tempObject2.transform.position = Vtemp;

            //入れ替え用オブジェクトの中身をnull
            temp = null;
            tempObject1 = null;
            tempObject2 = null;

            //団子が揃っているか判断
           clearScript.isComplete();
        }


    }

    public void TapObject()
    {

        count += 1;

        if (count != 1)
        {
            return;
        }

        GameObject parent = null;

        GameObject tapGameobject;
        if (Input.GetMouseButtonDown(0))
        {
            tapGameobject = null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2D)
            {
                //マウスでタッチした串オブジェクトを親オブジェクトとする
                tapGameobject = hit2D.transform.gameObject;
                parent = tapGameobject;
            }
        }

        //Emptyではない団子を上から調べる
        for (int i = 0; i < 4; i++)
        {
            //親オブジェクトの下の子オブジェクトを取得
            child = parent.transform.GetChild(i).gameObject;

            //子オブジェクトから孫オブジェクトを取得
            mago = child.transform.GetChild(0).gameObject;
            //団子がEmptyでなければその団子を入れ替え変数に代入する
            if (mago.gameObject.tag != "Empty")
            {
                tempObject1 = mago;
                return;
            }
        }

    }

    public void Move()
    {
        if (count != 2)
        {
            return;
        }
        count += 1;



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


        int emptyCount = 0;
        //Emptyではない団子を上から調べる
        for (int i = 0; i < 4; i++)
        {
            //親オブジェクトの下の子オブジェクトを取得
            child = parent.transform.GetChild(i).gameObject;

            //子オブジェクトから孫オブジェクトを取得
            mago = child.transform.GetChild(0).gameObject;

            //団子がEmptyでなければ一つ上のEmptyを入れ替え変数に代入する
            if (mago.gameObject.tag != "Empty" && mago.gameObject != tempObject1)
            {
                child = parent.transform.GetChild(i - 1).gameObject;
                mago = child.transform.GetChild(0).gameObject;
                tempObject2 = mago;
                return;
            }
            else
            {
                //空の団子の個数を数える
                emptyCount++;
            }

            //もし串に団子が刺さっていなかったら一番下のEmptyを入れ替え変数に代入する
            if (emptyCount == 4 && mago.gameObject.tag == "Empty")
            {
                mago = child.transform.GetChild(0).gameObject;
                tempObject2 = mago;
                return;
            }
        }
    }

    









}
