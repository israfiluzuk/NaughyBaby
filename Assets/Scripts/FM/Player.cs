using DG.Tweening;

public class Player : Human
{  
    protected override void Awake()
    {
        base.Awake();
        PlayAnim(AnimationType.IdleSit1,.3f);  
    }

}
