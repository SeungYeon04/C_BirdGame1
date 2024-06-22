using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class channelOB : MonoBehaviour
{
    public GameObject chnnelScrin; 

    public void chnnelOpen()
    {
        chnnelScrin.SetActive(true);
    }

    public void chnnelBack()
    {
        chnnelScrin.SetActive(false);
    }
}
