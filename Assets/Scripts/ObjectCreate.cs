using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreate : MonoBehaviour
{
    public GameObject kusiPrefab;       //串Prefabをアタッチ
    public GameObject[] dangoPrefab;    //それぞれの団子のPrefabをアタッチ
    public GameObject[] dangoPosition;  //団子の座標になる空オブジェクトをアタッチ
    public GameObject[] KUSIPosition;  //串の座標になる空オブジェクトをアタッチ

    //表示している団子の種類ごとに個数をカウントするための変数
    private struct Count
    {
        public int anko;
        public int goma;
        public int kinako;
        public int mitarasi;
        public int siratama;
        public int yomogi;
        public int empty;
    }
    Count count;


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

        //二種類の団子をランダムで表示
        int seedRand1 = Random.Range(0, 5);
        int seedRand2 = Random.Range(0, 5);
        if (seedRand1 == seedRand2 || seedRand2 == seedRand1)
        {
            seedRand2 = Random.Range(0, 5);
        }
        int[] rnd = new int[2];
        rnd[0] = seedRand1;
        rnd[1] = seedRand2;

        for (int i = 0; i < dangoPosition.Length; i++)
        {
            //団子用の座標オブジェクトを親オブジェクトにする
            parent[i] = dangoPosition[i].transform;

            //団子Prefab配列の添え字用変数
            int dangoRandom = Random.Range(0, 2);


            //団子Prefabをインスタンス化
            GameObject dangoObject = Instantiate(dangoPrefab[rnd[dangoRandom]], parent[i].transform.position, Quaternion.identity, parent[i]);


           
            //switch文でtagを使って各団子をカウント
            switch (dangoObject.tag)
            {
                case "ANKO":
                    count.anko++;
                    //団子が4個以上になったらオブジェクトを消して空っぽの団子オブジェクトを入れる
                    if (count.anko > 4)
                    {
                        Destroy(dangoObject);
                        dangoObject = Instantiate(dangoPrefab[6], parent[i].transform.position, Quaternion.identity, parent[i]);
                        count.empty++;
                    }
                    break;
                case "GOMA":
                    count.goma++;
                    if (count.goma > 4)
                    {
                        Destroy(dangoObject);
                        dangoObject = Instantiate(dangoPrefab[6], parent[i].transform.position, Quaternion.identity, parent[i]);
                        count.empty++;
                    }
                    break;
                case "KINAKO":
                    count.kinako++;
                    if (count.kinako > 4)
                    {
                        Destroy(dangoObject);
                        dangoObject = Instantiate(dangoPrefab[6], parent[i].transform.position, Quaternion.identity, parent[i]);
                        count.empty++;
                    }
                    break;
                case "MITARASI":
                    count.mitarasi++;
                    if (count.mitarasi > 4)
                    {
                        Destroy(dangoObject);
                        dangoObject = Instantiate(dangoPrefab[6], parent[i].transform.position, Quaternion.identity, parent[i]);
                        count.empty++;
                    }
                    break;
                case "SIRATAMA":
                    count.siratama++;
                    if (count.siratama > 4)
                    {
                        Destroy(dangoObject);
                        dangoObject = Instantiate(dangoPrefab[6], parent[i].transform.position, Quaternion.identity, parent[i]);
                        count.empty++;
                    }
                    break;
                case "YOMOGI":
                    count.yomogi++;
                    if (count.yomogi > 4)
                    {
                        Destroy(dangoObject);
                        dangoObject = Instantiate(dangoPrefab[6], parent[i].transform.position, Quaternion.identity, parent[i]);
                        count.empty++;
                    }
                    break;
                case "Empty":
                    count.empty++;
                    if (count.empty > 4)
                    {
                        Destroy(dangoObject);
                        dangoRandom = Random.Range(0, 2);
                        dangoObject = Instantiate(dangoPrefab[rnd[dangoRandom]], parent[i].transform.position, Quaternion.identity, parent[i]);
                    }
                    break;

            }

            //GameObject temp = dangoObject;
            //Debug.Log(dangoObject);
            //Debug.Log(ankoCount);
            //Debug.Log(gomaCount);
        }
    }


}
