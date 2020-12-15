using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    public string Name => name;
    public float Weight => weight;

    [SerializeField] private new string name;
    [SerializeField] private float weight;
}
