using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGvrController : MonoBehaviour
{

    void Update()
    {

        if (DontDestroy.playerData.VRMode)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

}
