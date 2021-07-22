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
        //スクリプトをアタッチしたオブジェクトを親オブジェクトにする
        //Transform parent = this.transform;

        Transform[] parent = new Transform[4];
        for (int i = 0; i < dangoPosition.Length; i++)
        {
            parent[i] = dangoPosition[i].transform;

            //団子Prefabをインスタンス化
            GameObject dangoObject = Instantiate(dangoPrefab[Random.Range(0, 5)], parent[i].transform.position, Quaternion.identity, parent[i]);
        }
    }
}
