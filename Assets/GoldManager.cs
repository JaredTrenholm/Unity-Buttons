using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public float gold;
    public int price = 100;
    public Button buyButton;
    public Text goldTxt;
    public Slider slider;

    private void Update()
    {
        goldTxt.text = "Gold: " + gold;
        if(gold >= price)
        {
            ButtonManager.buttonManager.EnableObject(buyButton.gameObject);
        } else
        {
            ButtonManager.buttonManager.DisableObject(buyButton.gameObject);
        }
    }
    public void Buy()
    {
        gold -= price;
        slider.value = gold;
    }
    public void AdjustGold(float value)
    {
        gold = value;
    }
}
