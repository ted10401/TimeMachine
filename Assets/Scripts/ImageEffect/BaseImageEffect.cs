using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseImageEffect : MonoBehaviour
{
    protected string _shaderName;
    protected Material _material;

    public virtual void Awake ()
    {
        CreateMaterial();
    }


    private void CreateMaterial()
    {
        _material = new Material(Shader.Find(_shaderName));

        InitPropertyIDs();
    }


    public virtual void InitPropertyIDs()
    {
        
    }


    private void OnRenderImage (RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit (source, destination, _material);
    }
}
