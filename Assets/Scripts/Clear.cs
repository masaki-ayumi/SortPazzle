using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    //表示している団子の種類ごとに個数をカウントするための変数
    private struct Count
    {
        public int anko;
        public int goma;
        public int kinako;
        public int mitarasi;
        public int siratama;
        public int yomogi;
    }
    Count count;

    //他のスクリプトの変数を持ってくるためのもの
    ObjectCreate objectcreateScript;

    //串ごとの団子用配列
    public GameObject[] dangoPosition = new GameObject[4];
    public GameObject[] dangoPosition1 = new GameObject[4];
    public GameObject[] dangoPosition2 = new GameObject[4];

    //子オブジェクト用変数
    GameObject child;
    

    // Start is called before the first frame update
    void Start()
    {
        //ObjectCreateスクリプトを代入
        objectcreateScript = this.GetComponent<ObjectCreate>();
    }

    // Update is called once per frame
    void Update()
    {


    }


    //団子の種類が串ごとにそろってるかみる
    public void isComplete()
    {
        dangocheck(dangoPosition);
        dangocheck(dangoPosition1);
        dangocheck(dangoPosition2);
    }

    //串についてる団子が揃っているか調べる関数
    public void dangocheck(GameObject[] dango)
    {
        count.anko = 0;
        count.goma = 0;
        count.kinako = 0;
        count.mitarasi = 0;
        count.siratama = 0;
        count.yomogi = 0;

        //団子を上から調べる
        for (int i = 0; i < 4; i++)
        {
            //親オブジェクトの下の子オブジェクトを取得
            child = dango[i].transform.GetChild(0).gameObject;

           
            //switch文でtagを使って各団子をカウント
            switch (child.tag)
            {
                case "ANKO":
                    count.anko++;
                    if (count.anko == objectcreateScript.count.anko)
                    {
                        Debug.Log("そろった");
                        count.anko = 0;
                    }

                    break;
                case "GOMA":
                    count.goma++;
                    if (count.goma == objectcreateScript.count.goma)
                    {
                        Debug.Log("そろった");
                        count.goma = 0;
                    }
                    break;
                case "KINAKO":
                    count.kinako++;
                    if (count.kinako == objectcreateScript.count.kinako)
                    {
                        Debug.Log("そろった");
                        count.kinako = 0;
                    }
                    break;
                case "MITARASI":
                    count.mitarasi++;
                    if (count.mitarasi == objectcreateScript.count.mitarasi)
                    {
                        Debug.Log("そろった");
                        count.mitarasi = 0;
                    }
                    break;
                case "SIRATAMA":
                    count.siratama++;
                    if (count.siratama == objectcreateScript.count.siratama)
                    {
                        Debug.Log("そろった");
                        count.siratama = 0;
                    }
                    break;
                case "YOMOGI":
                    count.yomogi++;
                    if (count.yomogi == objectcreateScript.count.yomogi)
                    {
                        Debug.Log("そろった");
                        count.yomogi = 0;
                    }
                    break;
            }
        }
    }
}
