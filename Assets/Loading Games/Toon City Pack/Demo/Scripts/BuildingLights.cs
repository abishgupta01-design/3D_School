using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLights : MonoBehaviour
{
    public int windowMaterialIndex;
    public Color lightColor = Color.yellow;
    public bool areLightsOn;

    private Color defaultColor = Color.white;
    private MeshRenderer mr;
    private Material windowMat;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();

        windowMat = mr.materials[windowMaterialIndex];

        // Change shader to URP Lit
        windowMat.shader = Shader.Find("Universal Render Pipeline/Lit");

        // Store default color
        if (windowMat.HasProperty("_BaseColor"))
        {
            defaultColor = windowMat.GetColor("_BaseColor");
        }

        SetLights(areLightsOn);
    }

    public void SetLights(bool isOn)
    {
        if (windowMat == null) return;

        if (windowMat.HasProperty("_BaseColor"))
        {
            windowMat.SetColor("_BaseColor",
                isOn ? lightColor : defaultColor);
        }
    }
}
