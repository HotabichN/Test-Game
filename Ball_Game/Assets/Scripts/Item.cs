using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType {
    Empty,
    Ball,
    Barrel,
    Box,
    Stone,
    Dinamit,
    Star
}
public class Item : MonoBehaviour
{
    public ItemType ItemType;
}

