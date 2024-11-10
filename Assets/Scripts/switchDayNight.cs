using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDayNight : MonoBehaviour
{
    public Light directionalLight; // Reference to the directional light

    // Color values for day and night (intensity in RGB)
    private Color dayColor = new Color(200f / 255f, 200f / 255f, 200f / 255f);
    private Color nightColor = new Color(0f, 0f, 0f);

    // Toggle between day and night
    public void ToggleLighting()
    {
        if (directionalLight.color == dayColor)
        {
            directionalLight.color = nightColor;
        }
        else
        {
            directionalLight.color = dayColor;
        }
    }
}
