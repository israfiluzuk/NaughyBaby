using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : Human
{
    protected override void Awake()
    {
        base.Awake();
        PlayAnim(AnimationType.IdleSit2,.3f);  
    }
}
