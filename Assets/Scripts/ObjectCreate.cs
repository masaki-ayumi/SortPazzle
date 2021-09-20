using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreate : MonoBehaviour
{
    public GameObject kusiPrefab;       //串Prefabをアタッチ
    public GameObject[] dangoPrefab;    //それぞれの団子のPrefabをアタッチ
    public GameObject[] dangoPosition;  //団子の座標になる空オブジェクトをアタッチ
    public GameObject[] KUSIPosition;  //串の座標になる空オブジェクトをアタッチ

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        //それぞれのインスタンスを生成
        CreateKUSIObject();
        CreateDANGOObject();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //串のオブジェクト生成用関数
    public void CreateKUSIObject()
    {
        //親オブジェクト配列
        Transform[] parent = new Transform[3];

        for (int i = 0; i < KUSIPosition.Length; i++)
        {
            //串用の座標オブジェクトを親オブジェクトにする
            parent[i] = KUSIPosition[i].transform;


            //串Prefabをインスタンス化
            GameObject kusiObject = Instantiate(kusiPrefab, parent[i].transform.position, Quaternion.identity, parent[i]);
        }
    }

    //お団子のオブジェクト生成用関数
    public void CreateDANGOObject()
    {
        //親オブジェクト配列
        Transform[] parent = new Transform[12];

        for (int i = 0; i < dangoPosition.Length; i++)
        {
            //団子用の座標オブジェクトを親オブジェクトにする
            parent[i] = dangoPosition[i].transform;

            //団子Prefabをインスタンス化
            GameObject dangoObject = Instantiate(dangoPrefab[Random.Range(0, 7)], parent[i].transform.position, Quaternion.identity, parent[i]);


            /*TODO:生成される団子prefabを制限する
                   一種類につき四つまでに制限*/

            //tagをつかって生成された団子をカウントする

            if (dangoObject.tag == "GOMA")
            {
                count++;

            }


            GameObject temp = dangoObject;
            Debug.Log(dangoObject);
            Debug.Log(count);
        }
    }


}
