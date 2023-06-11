using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    [SerializeField]
    public string Name;
    [SerializeField]
    public float HitPoint;

    private float maxHitPoint => HitPoint;

    public float GetMaxHitPoint
    {
        get { return maxHitPoint; }
    }

    [SerializeField]
    public float MagicPoint;

    private float maxMagicPoint => MagicPoint;

    public float GetMaxMagicPoint
    {
        get { return maxMagicPoint; }
    }

    [SerializeField]
    public float Speed;
    [SerializeField]
    public float PhysicalAttackPower;
    [SerializeField]
    public float MagicAttackPower;

    [SerializeField]
    public enum CharacterTypes
    {
        Invalide = -1,
        Fighter,
        SpellCaster,
    }

    [SerializeField]
    public CharacterTypes CharacterType;

    [SerializeField]
    public GameObject CharacterPrefab;

    public void Initialize(CharacterData characterData)
    {
        this.Name = characterData.Name;
        this.HitPoint = characterData.HitPoint;
        this.MagicPoint = characterData.MagicPoint;
        this.Speed = characterData.Speed;
        this.PhysicalAttackPower = characterData.PhysicalAttackPower;
        this.MagicAttackPower = characterData.MagicAttackPower;
        this.CharacterType = characterData.CharacterType;
        this.CharacterPrefab = characterData.CharacterPrefab;
    }

}
