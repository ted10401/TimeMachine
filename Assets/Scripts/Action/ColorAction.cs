using UnityEngine;

public class ColorAction : BaseAction
{
    [SerializeField] private Color _color;
    private Color _preColor;
    private Material _material;

    private void Awake()
    {
        _material = GetComponent<Renderer>().sharedMaterial;
    }

    public override void Action()
    {
        if (_material.color == _color)
            return;

        _preColor = _material.color;
        _material.color = _color;

        TimelineManager.Instance.AddReverseAction(ReverseAction);
    }

    public override void ReverseAction()
    {
        _material.color = _preColor;
    }
}
