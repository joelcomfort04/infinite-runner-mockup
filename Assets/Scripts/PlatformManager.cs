using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformManager : MonoBehaviour
{

    public GameObject[] platforms;
  


    public GameObject RandomPlatform()
    {
       
        return platforms[Random.Range(0, platforms.Length)];
        
    }
}
