using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float rotateSpeed = 20f;
    public Color newColor;
    public Color oldColor;
    
    Material material;
    float changeColorSpeed = 3f;

    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        material = Renderer.material;

        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);

        InvokeRepeating("ChangeColor", changeColorSpeed, changeColorSpeed);
    }
    
    void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    void ChangeColor()
    {
        oldColor = material.color;
        newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(.5f, 1f));
        
        material.color = Color.Lerp(oldColor, newColor, changeColorSpeed);
    }
}
