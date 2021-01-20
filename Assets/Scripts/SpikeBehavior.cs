using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehavior : MonoBehaviour
{
  


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject incomingObject = collision.gameObject;
        if(incomingObject.tag == "Mushroom")
        {
            Debug.Log("Mushroom touching spike");
            Destroy(incomingObject);
        }
        if (incomingObject.tag == "Player")
        {
            Destroy(incomingObject);
        }


    }

}
