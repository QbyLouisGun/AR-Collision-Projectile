using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectorCode : MonoBehaviour
{
    public int Collided;
    
    public void OnCollisionEnter(Collision collision)
    {
        string otherobject = collision.gameObject.name;
        Debug.Log("Collided with " + otherobject);
        Collided = 1;
        Debug.Log(Collided);
    }
}
