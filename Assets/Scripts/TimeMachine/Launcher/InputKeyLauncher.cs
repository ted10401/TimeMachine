using UnityEngine;

public class InputKeyLauncher : BaseLauncher
{
    public enum KeyType
    {
        Key,
        KeyDown,
        KeyUp,
        None
    }

    [SerializeField] private KeyType _keyType = KeyType.None;
    [SerializeField] private KeyCode _keycode = KeyCode.Space;

    private void Update ()
    {
        switch (_keyType)
        {
            case KeyType.Key:
                if (Input.GetKey(_keycode))
                {
                    Action();
                }
                break;
            case KeyType.KeyDown:
                if (Input.GetKeyDown(_keycode))
                {
                    Action();
                }
                break;
            case KeyType.KeyUp:
                if (Input.GetKeyUp(_keycode))
                {
                    Action();
                }
                break;
        }
	}
}
