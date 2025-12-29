using UnityEngine;

public class KeybindManager
{
    public static KeybindManager instance = new KeybindManager();
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode attackKey = KeyCode.Mouse0;
}
