using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Human : Animations
{
    private Rigidbody _rb;
    protected Rigidbody rb
    {
        get
        {
            if (_rb == null)
            {
                _rb = GetComponent<Rigidbody>();
            }
            return _rb;
        }
    }

    internal void HumanTurn(float value)
    {
        PlayAnim(AnimationType.TurnToKidPersonOne);
        transform.DORotate(new Vector3(0, value, 0), .75f);
    }

    internal void Walking(float value)
    {
        PlayAnim(AnimationType.WalkToKid);
        if (transform.localPosition.z != -1.5f)
            transform.DOLocalMoveZ(value, 1.2f);
    }

    internal void ParentSitting()
    {
        PlayAnim(AnimationType.ParentSitting, .3f, true);
    }

    public void PersonStandingUp()
    {
        PlayAnim(AnimationType.StandingUp, 1f, true);
    }
    public void ManChairSitting()
    {
        PlayAnim(AnimationType.ManSitting, 1f, true);
    }
    public void ManDisbelief()
    {
        PlayAnim(AnimationType.ManDisbelief, 1f, true);
    }
}
