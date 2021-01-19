using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PersonOne : Human
{
    public static PersonOne Instance;

    [SerializeField] Transform foodPos;

    protected override void Awake()
    {
        Instance = this;
        base.Awake();
        Talking();
    }

    internal void Talking()
    {
        PlayAnim(AnimationType.MomTalking);
    }

    internal void Relocate()
    {
        transform.position = foodPos.position;
        transform.rotation = foodPos.rotation;
        transform.localScale = foodPos.localScale;
    }
}
