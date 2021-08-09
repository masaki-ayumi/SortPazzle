using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public bool isTouch;
    // Start is called before the first frame update
    void Start()
    {
        isTouch = false;
    }

    // Update is called once per frame
    void Update()
    {
        TapController tapScript = this.gameObject.GetComponent<TapController>();
        isTouch = tapScript.isTouch;
        if (isTouch == false)
            tapScript.isTouch = isTouch;
    }

    public void Move()
    {
        if (isTouch==false)
        {
            return;
        }

        Debug.Log("団子タッチ");
        isTouch = false;
    }
}
