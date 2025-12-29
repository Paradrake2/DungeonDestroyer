using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    KeybindManager keybinds = KeybindManager.instance;
    public PlayerStats stats;
    void Start()
    {
        stats = PlayerStats.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keybinds.upKey))
        {
            transform.Translate(Vector3.up * stats.GetStatValue(PlayerStat.MoveSpeed) * Time.deltaTime);
        }
        if (Input.GetKey(keybinds.downKey))
        {
            transform.Translate(Vector3.down * stats.GetStatValue(PlayerStat.MoveSpeed) * Time.deltaTime);
        }
        if (Input.GetKey(keybinds.leftKey))
        {
            transform.Translate(Vector3.left * stats.GetStatValue(PlayerStat.MoveSpeed) * Time.deltaTime);
        }
        if (Input.GetKey(keybinds.rightKey))
        {
            transform.Translate(Vector3.right * stats.GetStatValue(PlayerStat.MoveSpeed) * Time.deltaTime);
        }
    }
}
