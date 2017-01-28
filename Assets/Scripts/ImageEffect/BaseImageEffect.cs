using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseImageEffect : MonoBehaviour
{
    [SerializeField] private Shader _shader;
    protected Material _material;

    public virtual void Awake ()
    {
        CreateMaterial();
    }


    private void CreateMaterial()
    {
        _material = new Material(_shader);

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
