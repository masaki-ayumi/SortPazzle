using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreate : MonoBehaviour
{
    public GameObject kusiPrefab;       //串Prefabをアタッチ
    public GameObject[] dangoPrefab;    //それぞれの団子のPrefabをアタッチ
    public GameObject[] dangoPosition;  //団子の座標になる空オブジェクトをアタッチ
    public GameObject[] KUSIPosition;  //串の座標になる空オブジェクトをアタッチ

    int ankoCount = 0;
    int gomaCount = 0;
    int emptyCount = 0;

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

            //団子Prefab配列の添え字用変数
            int dangoRandom = Random.Range(0, 2);

            //団子Prefabをインスタンス化
            GameObject dangoObject = Instantiate(dangoPrefab[dangoRandom], parent[i].transform.position, Quaternion.identity, parent[i]);


            /*TODO:生成される団子prefabを制限する
                   一種類につき四つまでに制限*/

            //tagをつかって生成された団子をカウントする

            //if (dangoObject.tag == dangoPrefab[dangoRandom].tag)
            //{
            //    count++;
            //    //Destroy(dangoObject);
            //    //dangoObject = Instantiate(dangoPrefab[4], parent[i].transform.position, Quaternion.identity, parent[i]);
            //}

            //switch文でtagを使って各団子をカウント
            switch (dangoObject.tag)
            {
                case "ANKO":
                    ankoCount++;
                    if (ankoCount > 4)
                    {
                        Destroy(dangoObject);
                        dangoObject = Instantiate(dangoPrefab[6], parent[i].transform.position, Quaternion.identity, parent[i]);
                    }
                    break;
                case "GOMA":
                    gomaCount++;
                    if (gomaCount > 4)
                    {
                        Destroy(dangoObject);
                        dangoObject = Instantiate(dangoPrefab[6], parent[i].transform.position, Quaternion.identity, parent[i]);
                    }
                    break;
                case "KINAKO":
                    break;
                case "MITARASI":
                    break;
                case "SIROTAMA":
                    break;
                case "YOMOGI":
                    break;
                case "Empty":
                    emptyCount++;
                    break;

            }

            GameObject temp = dangoObject;
            Debug.Log(dangoObject);
            Debug.Log(ankoCount);
            Debug.Log(gomaCount);
        }
    }


}
