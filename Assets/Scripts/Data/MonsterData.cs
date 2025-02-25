using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Monster/MonsterData")]
public class MonsterData : ScriptableObject
{
    public string monsterName;
    public int hp;
    public int attack;
    public string description;
    public Sprite monsterSprite;
}
