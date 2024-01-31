using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    private Enemy enemy;
    private ItemDrop myDropSystem;
    // Start is called before the first frame update

    [Header("Level Details")]
    [SerializeField] private int level = 1;

    [Range(0f, 1f)]
    [SerializeField] private float percentageModifier = .4f;

    protected override void Start()
    {
        base.Start();

        enemy = GetComponent<Enemy>();
        myDropSystem = GetComponent<ItemDrop>();

        ApplyLevelModifiers();
    }

    private void ApplyLevelModifiers()
    {
        Modify(strength);
        Modify(agility);
        Modify(intelligence);
        Modify(vitality);

        Modify(damage);
        Modify(critChance);
        Modify(critPower);


        Modify(maxHealth);
        Modify(armor);
        Modify(evasion);
        Modify(magicResistance);

        Modify(fireDamage);
        Modify(iceDamage);
        Modify(lightningDamage);
    }

    private void Modify(Stat _stat)
    {
        for(int i = 1; i< level; i++)
        {
            float modifier = _stat.GetValue() * percentageModifier;

            _stat.AddModifier(Mathf.RoundToInt(modifier));
        }
    }

    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);

    }

    public override void Die()
    {
        base.Die();
        enemy.Die();

        myDropSystem.GenerateDrop();
    }
}
