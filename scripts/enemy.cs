using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    //private bool restart;

    // Update is called once per frame
    void Update()
    {

        /*if (transform.localPosition.x < -11115f)
        {
            transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
        }*/
        transform.Translate(-Time.deltaTime*10 , 0, 0);
    }

}

