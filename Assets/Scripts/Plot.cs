using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour {

    private SpriteRenderer mySpriteRenderer;
    private PlantData currentPlant;

    private Color currentColor;
    private Color originalColor;
    private Color deadColor;

    private bool mouseOver = false;

    private int lives = 0;

    private void Start() {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        GameController.GetPrimary().RegisterPlot(this);

        originalColor = mySpriteRenderer.color;
        currentColor = mySpriteRenderer.color;

        deadColor = mySpriteRenderer.color;
        deadColor.r = deadColor.r / 4;
        deadColor.g = deadColor.g / 4;
        deadColor.b = deadColor.b / 4;
    }

    public void Starve() {
        lives--;
        if (lives <= 0) {
            currentColor = deadColor;
            if (!mouseOver) {
                mySpriteRenderer.color = currentColor;
            }
            // dead
        }
    }

    public PlantData GetPlant() {
        return currentPlant;
    }

    public void OnMouseEnter() {
        mouseOver = true;

        if (GameController.GetPrimary().IsShovelSelected()) {
            if (currentPlant == null) {
                return;
            }
            mySpriteRenderer.sprite = GameController.GetPrimary().GetShovelSprite();
            mySpriteRenderer.color = originalColor;
        } else if (currentPlant == null) {
            mySpriteRenderer.sprite = GameController.GetPrimary().GetSelectedPlant().GetSprite();
            mySpriteRenderer.color = originalColor;
            UpdateAlpha(0.5f);
        }
    }

    public void OnMouseExit() {
        mouseOver = false;
        if (currentPlant != null) {
            UpdateAlpha(1f);
            mySpriteRenderer.color = currentColor;
            mySpriteRenderer.sprite = currentPlant.GetSprite();
        } else {
            UpdateAlpha(0f);
        }
    }

    private void OnMouseDown() {
        if (GameController.GetPrimary().IsShovelSelected()) {
            currentPlant = null;
            UpdateAlpha(0f);
        } else {
            if (currentPlant != null) {
                return;
            }
            UpdateAlpha(1f);
            currentPlant = GameController.GetPrimary().GetSelectedPlant();
            mySpriteRenderer.sprite = currentPlant.GetSprite();
            currentColor = originalColor;
            lives = currentPlant.GetLives();
        }
    }

    private void UpdateAlpha(float newAlpha) {
        Color newColor = mySpriteRenderer.color;
        newColor.a = newAlpha;
        mySpriteRenderer.color = newColor;
    }
}
