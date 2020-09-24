using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Panel", menuName = "Panel")]
public class Panel : ScriptableObject
{
    public string title;
    public Sprite image;
    public string text;
}
