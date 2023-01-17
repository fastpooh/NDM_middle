using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChange : MonoBehaviour
{
    private Renderer r;

    void Start()
    {
        r = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        Color customColor = new Color(0.906f, 0.631f, 0.69f, 1.0f);
        r.material.color = customColor;
    }

    private void OnMouseExit()
    {
        Color customColor = new Color(0.651f, 0.651f, 0.651f, 1.0f);
        r.material.color = customColor;
    }
}
