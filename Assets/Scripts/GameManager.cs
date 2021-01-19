using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;
using Animancer;

public class GameManager : LocalSingleton<GameManager>
{
    [SerializeField] GameObject questionUI;
    [SerializeField] Button optionOne;
    [SerializeField] Button optionTwo;
    [SerializeField] Player baby;
    [SerializeField] Player babyFriend;
    [SerializeField] Camera mainCamera;
    public Transform kidRoomCamPos;
    public Transform FoodTableCamPos;
    public Image cameraFadePanel;
    [SerializeField] Transform babyTransfomPos2;
    [SerializeField] Transform babyTransfomPos3;
    [SerializeField] Transform ballPosSecond;
    [SerializeField] GameObject kidBall;
    [SerializeField] GameObject fork;
    void Start()
    {
        kidBall.SetActive(false);
        fork.SetActive(false);
        baby.PlayAnim(AnimationType.IdleSit1, .3f, false);
        babyFriend.PlayAnim(AnimationType.SitIdleHappy);
        questionUI.SetActive(false);
        optionOne.onClick.AddListener(() => OptionOneFunction());
        optionTwo.onClick.AddListener(() => OptionTwoFunction());
    }

    internal void PlayerThrowObject()
    {
        baby.PlayAnim(AnimationType.ThrowObject, 0, true);
        PaintIn3D.P3dTapThrow.isThrown = true;
        StartCoroutine(BallThrow());
    }

    IEnumerator BallThrow()
    {
        //Debug.Break();
        GameObject thrownBall = null;
        while (thrownBall == null)
        {
            yield return new WaitForEndOfFrame();
            thrownBall = GameObject.FindWithTag("ball");
        }
        thrownBall.transform.SetParent(kidBall.transform);
        thrownBall.transform.localPosition = Vector3.zero;

        yield return new WaitForSeconds(.9f);
        kidBall.transform.SetParent(null);
        kidBall.transform.DOMove(ballPosSecond.position,.18f);
    }


    internal void SitUp()
    {
        baby.PlayAnim(AnimationType.SitUp);
    }

    internal void Cry()
    {
        babyFriend.PlayAnim(AnimationType.Cry);
    }

    internal void IdleSit2()
    {
        babyFriend.PlayAnim(AnimationType.IdleSit2);
    }

    private void OptionTwoFunction()
    {
        Debug.Log("Option Two Selected...");
    }

    private void OptionOneFunction()
    {
        Debug.Log("Option One Selected...");
    }

    internal void PrepareFoodScenario()
    {
        mainCamera.transform.position = FoodTableCamPos.position;
        mainCamera.transform.DOMove(FoodTableCamPos.position, 1);
        mainCamera.transform.DORotate(new Vector3(25, 120, 0), 1);
        baby.transform.position = babyTransfomPos3.position;
        baby.PlayAnim(AnimationType.HappyStanding);
        fork.SetActive(true);
    }

    internal void Hitting()
    {
        baby.PlayAnim(AnimationType.KidHitting, .3f, true);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            PrepareFoodScenario();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Hitting();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Cry();
        }

    }

    internal void HitObject()
    {
        baby.PlayAnim(AnimationType.KidHitting, .3f, true);
    }
    internal void Lauging()
    {
        baby.PlayAnim(AnimationType.Laugh);
    }
    internal void Jumping()
    {
        baby.PlayAnim(AnimationType.Jumping);
    }
    //objenin durumunu değiştirme
    void ChangeGOStatue(GameObject gameObject, bool value)
    {
        gameObject.SetActive(value);
    }

    internal void PlayerCry()
    {
        baby.PlayAnim(AnimationType.Cry);
    }

    internal void PlayerIdleSitting()
    {
        baby.PlayAnim(AnimationType.Sitting);
    }
    internal void PlayerUpSitting()
    {
        baby.PlayAnim(AnimationType.Upsitting);
    }
    internal void PlayerLieCry()
    {
        baby.gameObject.transform.localEulerAngles = new Vector3(0, 180, 0);
        baby.PlayAnim(AnimationType.LieCry, .8f);
    }
    internal void PlayerLieDown()
    {
        baby.gameObject.transform.localEulerAngles = new Vector3(0, 180, 0);
        baby.PlayAnim(AnimationType.LieCry, .8f);
    }

    internal void PlayerLieCrawl()
    {
        baby.gameObject.transform.localEulerAngles = new Vector3(0, 180, 0);
        baby.PlayAnim(AnimationType.LieCrawl);
    }
    internal void PlayerCrawlSit()
    {
        baby.PlayAnim(AnimationType.CrawlSit);
    }
    internal void PlayerSadSitting()
    {
        baby.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        baby.PlayAnim(AnimationType.SadSitting);
    }

    internal void PlayerAngrySitting()
    {
        baby.PlayAnim(AnimationType.AngrySitting);
    }

    internal void PlayerHappyStanding()
    {
        baby.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        baby.PlayAnim(AnimationType.HappyStanding);
    }

    internal void MoveCamera(int value)
    {
        if (value == 1)
        {
            baby.transform.position = babyTransfomPos2.position;
            baby.transform.localScale = babyTransfomPos2.localScale;
            babyTransfomPos2.transform.rotation = babyTransfomPos2.rotation;
            kidBall.SetActive(true);
            mainCamera.transform.DOMove(kidRoomCamPos.position, 1);
            mainCamera.transform.DORotate(new Vector3(25, 270, 0), 1);
        }
        else
            kidBall.SetActive(false);
    }

    internal void PlayerCrawlTurn90()
    {
        baby.gameObject.transform.localEulerAngles = new Vector3(0, 180, 0);
        baby.PlayAnim(AnimationType.CrawlTurn90);
        baby.transform.DORotate(new Vector3(0,0,0),1f);
    }

    internal void CameraSwitchFade()
    {
        cameraFadePanel.DOFade(1, .5f);
        MoveCamera(1);
        cameraFadePanel.DOFade(0, .5f);
    }

    internal void SitIdleHappy()
    {
        baby.PlayAnim(AnimationType.SitIdleHappy);
    }
}
