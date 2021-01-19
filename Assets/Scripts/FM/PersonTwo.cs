using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonTwo : Human
{
    public static PersonTwo Instance;
    [SerializeField] Transform foodPos;

    protected override void Awake()
    {
        Instance = this;
        base.Awake();
        Talking();
    }

    internal void Talking()
    {
        PlayAnim(AnimationType.DadTalking);
    }
    internal void Relocate()
    {
        transform.position = foodPos.position;
        transform.rotation = foodPos.rotation;
        transform.localScale = foodPos.localScale;
    }
}


