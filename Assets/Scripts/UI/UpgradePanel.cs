using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;
        print(1);
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
        print(2);
    }
}
