using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    public int kind;  //0:Terran , 1:zerg , 3:protoss

    public void toogleChoice(bool isON)
    {
        if (isON)
        {
            PlayerPrefs.SetInt("Kind", kind);
            Debug.Log(kind);
        }
        else
        {
            return;
        }
    }
}
