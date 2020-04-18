using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float moveSpeed = 1000f;
    public float turnSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }
       // if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
        }
       // if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * turnSpeed * Time.deltaTime);
        }
    }
}
