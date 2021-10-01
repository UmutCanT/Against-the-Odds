using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamHandler : MonoBehaviour
{
    Vector3 offset = new Vector3(0, 10, -10);
    Transform playerTra;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!playerTra)
        {
            playerTra = GameObject.FindGameObjectWithTag("Player").transform;
        }
        transform.position = playerTra.position + offset;
    }
}
