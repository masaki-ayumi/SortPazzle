using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreate : MonoBehaviour
{
    public GameObject prefabObject;
    public GameObject objectPosition;
    // Start is called before the first frame update
    void Start()
    {
        CreateGameobject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateGameobject()
    {
       Transform objPosition = objectPosition.transform;
       GameObject obj = Instantiate(prefabObject, objPosition.position, Quaternion.identity);
    }
}
