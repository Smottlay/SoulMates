using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    public float rotation;
    public float tijdUren;
    public float tijdMinuten;
    public Slider slider;
    // Update is called once per frame
    void Update()
    {
        tijdUren = slider.value / 60f;
        float rawMinuten = tijdUren - Mathf.Floor(tijdUren);
        tijdUren = Mathf.Floor(tijdUren);
        tijdMinuten = Mathf.Floor(rawMinuten * 60f);

        float procentVanDag = slider.value / 14.4f;
        rotation = 3.6f * procentVanDag;
    }
}
