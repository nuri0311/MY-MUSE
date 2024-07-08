using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeSeriesPaintings : MonoBehaviour
{
    public Renderer targetObject;
    void Start()
    {
        targetObject = gameObject.GetComponent<Renderer> ();

        Console.WriteLine("ChangeSeriesPaintings");

        //show series 2
        changeRenderMode(targetObject.materials[3], BlendMode.Fade);
        changeRenderMode(targetObject.materials[2], BlendMode.Opaque);
        System.Threading.Thread.Sleep(1000);
        //show series 3
        changeRenderMode(targetObject.materials[2], BlendMode.Fade);
        changeRenderMode(targetObject.materials[1], BlendMode.Opaque);
        System.Threading.Thread.Sleep(1000);
        //show series 1 (original image)
        changeRenderMode(targetObject.materials[1], BlendMode.Fade);
        changeRenderMode(targetObject.materials[3], BlendMode.Opaque);
        
    }

    public enum BlendMode
    {
        Opaque = 0,
        Cutout,
        Fade,
        Transparent
    }

    public static void changeRenderMode(Material standardShaderMaterial, BlendMode blendMode)
    {
        switch (blendMode)
        {
            case BlendMode.Opaque:
                standardShaderMaterial.SetFloat("_Mode",0.0f);
                standardShaderMaterial.SetOverrideTag("RenderType", "Opaque");
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                standardShaderMaterial.SetInt("_ZWrite", 1);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = -1;
                break;
            case BlendMode.Cutout:
                standardShaderMaterial.SetFloat("_Mode",1.0f);
                standardShaderMaterial.SetOverrideTag("RenderType", "Cutout");
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                standardShaderMaterial.SetInt("_ZWrite", 1);
                standardShaderMaterial.EnableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 2450;
                break;
            case BlendMode.Fade:
                standardShaderMaterial.SetFloat("_Mode",2.0f);
                standardShaderMaterial.SetOverrideTag("RenderType", "Fade");
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                standardShaderMaterial.SetInt("_ZWrite", 0);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.EnableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 3000;
                break;
            case BlendMode.Transparent:
                standardShaderMaterial.SetFloat("_Mode",3.0f);
                standardShaderMaterial.SetOverrideTag("RenderType", "Transparent");
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                standardShaderMaterial.SetInt("_ZWrite", 0);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 3000;
                break;
        }
    }
}
