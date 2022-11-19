using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCoin2 : MonoBehaviour
{

    public float speed;
    public float timeAcc;




    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame


    
    void Update()
    {
        if (transform.position.y < 0.5f)
        {
        }        
        else
        {
            timeAcc += Time.deltaTime;
            speed = rb.velocity.magnitude;
        }
    }
}
