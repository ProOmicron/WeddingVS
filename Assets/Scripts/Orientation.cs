using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientation : MonoBehaviour
{

    void Start()
    {
        if (Screen.currentResolution.height < 1920)
        {
            Screen.SetResolution(Screen.height / 16 * 9, Screen.height, true);
        }
        else
        {
            Screen.SetResolution(2160, 3840, true);
        }
    }
}
