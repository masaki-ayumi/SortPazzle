using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{

    private GameObject tempObject1;
    private GameObject tempObject2;

    public float count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //1と2を繰り返す
        if (count >= 3)
        {
            count = 0;
        }


        //TODO：一回目の🍡と二回目の🍡を入れ替える
        //TODO：親オブジェクトを入れ替え
        //TODO：座標を入れ替え

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




            //Debug.Log("temp1=" + tempObject1);
            //Debug.Log("temp2=" + tempObject2);

            //入れ替え用オブジェクトの中身をnull
            temp = null;
            tempObject1 = null;
            tempObject2 = null;
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


        //親オブジェクトの一つ下の子オブジェクトを取得
        GameObject child = parent.transform.GetChild(0).gameObject;

        //Debug.Log(child);        
        //子オブジェクトから孫オブジェクトを取得
        GameObject mago = child.transform.GetChild(0).gameObject;
        tempObject1 = mago;

        //Debug.Log(tempObject1);


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

        //親オブジェクトの一つ下の子オブジェクトを取得
        GameObject child = parent.transform.GetChild(0).gameObject;

        //Debug.Log(child);        
        //子オブジェクトから孫オブジェクトを取得
        GameObject mago = child.transform.GetChild(0).gameObject;

        tempObject2 = mago;
        //Debug.Log(tempObject2);
    }


}
