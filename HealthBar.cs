using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // declares and retrieves the elements that make the health bar
    [SerializeField] Slider slider;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;

    public void SetMaxHealth(int health)
    {
        // uses the given max health to construct the right slider lengths
        slider.maxValue = health;
        slider.value = health;

        // uses the bar's gradient to change the color based on % remaining
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        // changes the amount filled when health lowers
        slider.value = health;

        // finds the right gradient color to set the fill
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
