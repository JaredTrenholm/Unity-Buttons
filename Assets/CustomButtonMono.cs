using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomButtonMono : MonoBehaviour
{
    private Button button;
    public void SetButton(Button button)
    {
        this.button = button;
    }
    private void Update()
    {
        if (button == null)
        {
            Debug.Log(gameObject.name);
            this.gameObject.GetComponent<Button>();
        }
        if (ButtonManager.buttonManager.optionsOpened) button.enabled = false;
        else button.enabled = true;
    }
}
