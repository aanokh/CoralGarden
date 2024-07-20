using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Created by Alexander Anokhin

public class GameController : MonoBehaviour {

    public static GameController primary;

    [SerializeField] MineralManager mineralManager;
    [SerializeField] Image tickMeter;
    [SerializeField] PlantData startingPlant;
    [SerializeField] Sprite shovelSprite;

    [SerializeField] int tickLength = 5;

    private float tick = 0;

    private bool shovelSelected = false;
    private List<Plot> plots;
    private PlantData selectedPlant;

    // singleton
    private void Awake() {
        int count = FindObjectsOfType<GameController>().Length;

        if (count > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            // DontDestroyOnLoad(gameObject);
            primary = this;
        }
    }

    private void Start() {
        selectedPlant = startingPlant;
    }

    private void Update() {
        Tick();
    }

    private void Tick() {
        tick += Time.deltaTime;

        tickMeter.fillAmount = tick / tickLength;

        if (tick < tickLength) {
            return;
        }
         
        tick = 0;

        bool shortage = false;

        foreach (Plot plot in plots) {
            if (plot.GetPlant() != null) {
                shortage = mineralManager.SubtractMineral(plot.GetPlant().GetConsumption());

                if (shortage) {
                    plot.Starve();
                } else {
                    mineralManager.AddMineral(plot.GetPlant().GetProduction());
                }
            }
        }

        mineralManager.UpdateText();
    }

    public void RegisterPlot(Plot plot) {
        if (plots == null) {
            plots = new List<Plot>();
        }

        plots.Add(plot);
    }

    public void SetSelectedPlant(PlantData newPlant) {
        selectedPlant = newPlant;
        shovelSelected = false;
    }

    public PlantData GetSelectedPlant() {
        return selectedPlant;
    }

    public Sprite GetShovelSprite() {
        return shovelSprite;
    }

    public bool IsShovelSelected() {
        return shovelSelected;
    }

    public void SelectShovel() {
        shovelSelected = true;
    }

    public static GameController GetPrimary() {
        return primary;
    }
}
