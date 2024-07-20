using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Created by Alexander Anokhin

public class MineralManager : MonoBehaviour {

    private int redCount;
    private int blueCount;
    private int yellowCount;

    [SerializeField] Text redText;
    [SerializeField] Text blueText;
    [SerializeField] Text yellowText;

    public void AddMineral(ICollection<Mineral> minerals) {
        foreach (Mineral item in minerals) {
            if (item.Equals(Mineral.RED)) {
                redCount++;
            } else if (item.Equals(Mineral.BLUE)) {
                blueCount++;
            } else if (item.Equals(Mineral.YELLOW)) {
                yellowCount++;
            }
        }
    }

    public bool SubtractMineral(ICollection<Mineral> minerals) {
        bool shortage = false;

        foreach (Mineral item in minerals) {
            if (item.Equals(Mineral.RED)) {
                if (redCount > 0) {
                    redCount--;
                } else {
                    shortage = true;
                }
            } else if (item.Equals(Mineral.BLUE)) {
                if(blueCount > 0) {
                    blueCount--;
                } else {
                    shortage = true;
                }
            } else if (item.Equals(Mineral.YELLOW)) {
                if (yellowCount > 0) {
                    yellowCount--;
                } else {
                    shortage = true;
                }
            }
        }

        return shortage;
    }

    public void UpdateText() {
        redText.text = redCount.ToString();
        blueText.text = blueCount.ToString();
        yellowText.text = yellowCount.ToString();
    }

}
