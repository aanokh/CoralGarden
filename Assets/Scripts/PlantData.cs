using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Alexander Anokhin

[CreateAssetMenu(menuName = "Plant Data")]

public class PlantData : ScriptableObject {

    [SerializeField] Sprite sprite;
    [SerializeField] Mineral[] production;
    [SerializeField] Mineral[] consumption;
    [SerializeField] int cost;
    [SerializeField] int lives;

    public Sprite GetSprite() { return sprite; }

    public Mineral[] GetProduction() { return production; }

    public Mineral[] GetConsumption() { return consumption; }

    public int GetCost() { return cost; }

    public int GetLives() { return lives; }
}