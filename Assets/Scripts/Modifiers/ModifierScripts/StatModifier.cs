using UnityEngine;

[CreateAssetMenu(fileName = "StatModifier", menuName = "Modifiers/StatModifier")]
public class StatModifier : Modifier
{
    public Player player;
    public PlayerStat stat;
    public float value;
    public bool alreadyApplied = false;
    //new ModifierType modifierType = ModifierType.Player;
    public override void ApplyModifier()
    {
        if (player == null)
        {
            player = PlayerStats.instance.player;
        }
        if (alreadyApplied) return;
        
        player.ModifyStat(stat, value);
        alreadyApplied = true;
    }

}
