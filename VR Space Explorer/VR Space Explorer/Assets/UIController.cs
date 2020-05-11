using System.Collections;
using UnityEngine;

public class UIController : MonoBehaviour {
    void Update()
    {

        if (DontDestroy.playerData.VRMode)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
    
}
