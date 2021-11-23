using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager buttonManager;
    public Color disabledColor;
    public Color enabledColor;
    public GameObject optionsCanvas;
    public bool optionsOpened = false;
    private int sceneNum = 0;
    private Scene scene;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        if (buttonManager != null)
        {
            Destroy(this.gameObject);
        } else
        {
            buttonManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Update()
    {
        scene = SceneManager.GetActiveScene();
        sceneNum = scene.buildIndex;
        if (ButtonManager.buttonManager.optionsOpened) ButtonManager.buttonManager.optionsCanvas.SetActive(true);
        else ButtonManager.buttonManager.optionsCanvas.SetActive(false);
    }
    public void OpenOptions()
    {
        if (!ButtonManager.buttonManager.optionsOpened)
        {
            ButtonManager.buttonManager.optionsOpened = true;
            Time.timeScale = 0;
        }
        else
            CloseOptions();
    }
    public void CloseOptions()
    {
        ButtonManager.buttonManager.optionsOpened = false;
        Time.timeScale = 1;
    }
    public void ChangeToNextScene()
    {
        sceneNum++;
        Debug.Log(SceneManager.sceneCountInBuildSettings);
        if (sceneNum >= SceneManager.sceneCountInBuildSettings)
        {
            sceneNum = 0;
        }
        SceneManager.LoadScene(sceneNum);
    }
    public void GoBackwardsToScenes()
    {
        sceneNum--;
        if (sceneNum < 0)
        {
            sceneNum = SceneManager.sceneCountInBuildSettings-1;
        }
        SceneManager.LoadScene(sceneNum);
    }

    public void EnableObject(GameObject targetGameObject)
    {
        targetGameObject.GetComponent<Image>().color = ButtonManager.buttonManager.enabledColor;
        targetGameObject.GetComponent<Button>().enabled = true;
    }
    public void DisableObject(GameObject targetGameObject)
    {
        targetGameObject.GetComponent<Image>().color = ButtonManager.buttonManager.disabledColor;
        targetGameObject.GetComponent<Button>().enabled = false;
    }
}
