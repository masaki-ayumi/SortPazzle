using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreate : MonoBehaviour
{
    public GameObject kusiPrefab;       //串Prefabをアタッチ
    public GameObject[] dangoPrefab;    //それぞれの団子のPrefabをアタッチ
    public GameObject[] dangoPosition;  //団子の座標になる空オブジェクトをアタッチ
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
        //スクリプトをアタッチしたオブジェクトを親オブジェクトにする
        Transform parent = this.transform;

        //串Prefabをインスタンス化
        GameObject kusiObject = Instantiate(kusiPrefab, this.transform.position, Quaternion.identity, parent);
    }

    //お団子のオブジェクト生成用関数
    public void CreateDANGOObject()
    {
        //親オブジェクト配列
        Transform[] parent = new Transform[4];

        for (int i = 0; i < dangoPosition.Length; i++)
        {
            //団子用の座標オブジェクトを親オブジェクトにする
            parent[i] = dangoPosition[i].transform;

            //団子Prefabをインスタンス化
            GameObject dangoObject = Instantiate(dangoPrefab[Random.Range(0, 3)], parent[i].transform.position, Quaternion.identity, parent[i]);


            /*TODO:生成される団子prefabを制限する
                   一種類につき四つまでに制限*/

            //dangoPrefab[]とdangoObjectをつかって生成された団子をカウントする
            //switch文を使う？

            if (dangoObject == dangoPrefab[1])
                Debug.Log("aaaaa"); //なぜか通らない


            GameObject temp = dangoObject;
            Debug.Log(dangoPrefab[1]);
        }
    }

    
}
