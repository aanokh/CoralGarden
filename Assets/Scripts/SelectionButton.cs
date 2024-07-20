using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Created by Alexander Anokhin

public class SelectionButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    
    [SerializeField] PlantData plant;
    [SerializeField] Image icon;
    [SerializeField] GameObject tooltip;
    [SerializeField] bool isShovel = false;

    public void Start() {
        if (isShovel) {
            icon.sprite = GameController.GetPrimary().GetShovelSprite();
        } else {
            icon.sprite = plant.GetSprite();
        }
        
        tooltip.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData d) {
        tooltip.SetActive(true);
    }

    public void OnPointerExit(PointerEventData d) {
        tooltip.SetActive(false);
    }

    public void OnClick() {
        if (isShovel) {
            GameController.GetPrimary().SelectShovel();
        } else {
            GameController.GetPrimary().SetSelectedPlant(plant);
        }
    }
}
