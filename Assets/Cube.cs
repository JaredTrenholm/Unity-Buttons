
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        this.gameObject.AddComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*0.5f, Space.World);
        if(Vector3.Distance(this.gameObject.transform.position, Vector3.zero)>15f)
        {
            Destroy(this.gameObject);
        }   
    }
}
