using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationType
{
    IdleStand,
    IdleSit1,
    IdleSit2,
    Walk,
    Run,
    Cry,
    LieCry,
    Sitting,
    SadSitting,
    AngrySitting,
    HappyStanding,
    MomTalking,
    DadTalking,
    TurnToKidPersonOne,
    Smile,
    WalkToKid,
    ParentSitting,
    StandingUp,
    LieCrawl,
    CrawlSit,
    Upsitting,
    SitIdleHappy,
    KidHitting,
    Laugh,
    Jumping,
    ThrowObject,
    SitUp,
    ManSitting,
    ManDisbelief,
    CrawlTurn90
}
public class AnimationReferencer : LocalSingleton<AnimationReferencer>
{ 
    [System.Serializable]
    public class MyAnimation
    {
        public AnimationType animationType;
        public AnimationClip animation;
    }

    public MyAnimation[] animations; 
    public Avatar babyAvatar, parentAvatar;

}
