using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Button start;
    public Button stop;
    public Material[] colors;
    private bool isSpawning;
    void Update()
    {
        EnableButtons();
        if (isSpawning && Time.timeScale != 0)
        {
            for(int i = 0; i < colors.Length; i++)
            {
                if (Time.timeScale != 0)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.AddComponent<Cube>();
                    cube.GetComponent<Renderer>().material = colors[i];
                }
            }
           
            /*Material newMat = new Material(cube.GetComponent<Renderer>().material);
            Color color = new Color(Random.Range(0, 256), Random.Range(0, 256), Random.Range(0, 256), 255);
            newMat.color = color;
            cube.GetComponent<Renderer>().material = newMat;*/
        }
    }

    public void StartSpawning()
    {
        isSpawning = true;
        
    }
    public void StopSpawning()
    {
        isSpawning = false;
    }
    private void EnableButtons()
    {
        if (isSpawning)
        {
            ButtonManager.buttonManager.DisableObject(start.gameObject);
            ButtonManager.buttonManager.EnableObject(stop.gameObject);
        } else
        {
            ButtonManager.buttonManager.DisableObject(stop.gameObject);
            ButtonManager.buttonManager.EnableObject(start.gameObject);
        }
    }
}
