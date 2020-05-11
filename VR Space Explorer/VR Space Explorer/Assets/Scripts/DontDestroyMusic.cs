using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMusic : MonoBehaviour {
    public static DontDestroyMusic MusicData;
    void Awake()
    {
        if (MusicData == null)
        {
            DontDestroyOnLoad(gameObject);
            MusicData = this;
        }
        else if (MusicData != this)
        {
            Destroy(gameObject);
        }
    }
}
