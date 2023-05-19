using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =(""), menuName =(""))]
public class Test : ScriptableObject
{
    public int Id { get { return GetInstanceID(); } }

    [NonSerialized]
    public Sprite icon;
    public string Player_Name;
    public float Player_Speed;
    public float Player_Health;
}