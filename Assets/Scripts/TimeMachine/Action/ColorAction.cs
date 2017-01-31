using UnityEngine;

public class ColorAction : BaseAction
{
    [SerializeField] private Color _color;
    private Color _preColor;
    private Material _material;

    protected override void Initialize()
    {
        _material = GetComponent<Renderer>().sharedMaterial;
    }

    public override void Action()
    {
        if (_material.color == _color)
            return;

        _preColor = _material.color;
        _material.color = _color;

        TimeMachineManager.Instance.AddRewindAction(RewindAction);
    }

    public override void RewindAction()
    {
        _material.color = _preColor;
    }
}
