using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatforms : MonoBehaviour
{
    private GameObject nextPlatTarget;
    private Vector3 nextPlatPos;
    private GameObject parent;
    private GameObject platform;
    private bool canGenerate = true;
    public PlatformManager platformManager;
    

     void Start()
    {
        parent = transform.parent.gameObject;
        nextPlatTarget = GetChildWithName(parent, "NextPlatTarget");
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && canGenerate) 
        {

            float yPos = collision.gameObject.transform.position.y;
           canGenerate = false;
           platform = platformManager.RandomPlatform();
            if(yPos >= 80)
            {
                nextPlatPos = new Vector3(nextPlatTarget.transform.position.x + Random.Range(1.0f, 4.5f), nextPlatTarget.transform.position.y + 3.5f, nextPlatTarget.transform.position.z);
            }
            else
            {
                nextPlatPos = new Vector3(nextPlatTarget.transform.position.x + Random.Range(2.0f, 5.0f), nextPlatTarget.transform.position.y + Random.Range(-2.4f, 3.4f), nextPlatTarget.transform.position.z);
            }
           
           Instantiate(platform, nextPlatPos, Quaternion.identity);
  
        }
       
    }

   
    
    GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }

    

}
