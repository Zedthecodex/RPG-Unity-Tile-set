using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

    public EnemyStateMachine stateMachine { get; private set; }

    private void Awake()
    {
        
    }
}
