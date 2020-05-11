using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DontDestroy : MonoBehaviour
{
    public static DontDestroy playerData;

    public bool VRMode;

    void Awake()
    {
        if (playerData == null)
        {
            DontDestroyOnLoad(gameObject);
            playerData = this;
        }
        else if (playerData != this)
        {
            Destroy(gameObject);
        }
    }
}