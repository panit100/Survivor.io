using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "cardInfo",menuName = "UpgradeCard")]
public class UpgradeCardScriptableObject : ScriptableObject
{
    public Sprite image;
    public Vector3 imageSize;
    public string name;
    public string description;
}
