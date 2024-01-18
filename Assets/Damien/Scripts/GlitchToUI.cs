using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Graphic))] [ExecuteAlways]
public class GlitchToUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        m_myCanvasImage = GetComponent();
    }

    void OnValidate()
    { 
        UpdateMaterial(); 
    }

    void UpdateMaterial()
{
    if (m_myCanvasImage != null && m_myCanvasImage.material != null)
    {
        var imageRect = m_myCanvasImage.rectTransform.rect;
        var widthHeight = new Vector2(x: imageRect.width, y: imageRect.height);
       material.SetVector(name: "_Size", widthHeight);
    }
}
}
