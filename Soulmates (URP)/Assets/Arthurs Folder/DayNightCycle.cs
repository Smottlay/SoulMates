using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    float rotation;
    public GameObject directinalLight;
    public Slider slider;
    public Text tijdText;
    float tijdUren;
    float tijdMinuten;

    public void ChangeTime() {
        tijdUren = slider.value / 60f;
        float rawMinuten = tijdUren - Mathf.Floor(tijdUren);
        tijdUren = Mathf.Floor(tijdUren);
        tijdMinuten = Mathf.Floor(rawMinuten * 60f);

        float procentVanDag = slider.value / 14.4f;
        directinalLight.transform.rotation = Quaternion.Euler(03.6f * procentVanDag, 0, 0);
        if (tijdMinuten <= 9f) {
            tijdText.text = tijdUren.ToString() + ":0" + tijdMinuten.ToString();
        } else {
            tijdText.text = tijdUren.ToString() + ":" + tijdMinuten.ToString();
        }
    }
    public void MinuteMeer() {
        slider.value ++;
        ChangeTime();
    }
    public void MinuteMinder() {
        slider.value --;
        ChangeTime();
    }
    public void UurMeer() {
        slider.value += 60;
        ChangeTime();
    }
    public void UurMinder() {
        slider.value -= 60;
        ChangeTime();
    }
}
