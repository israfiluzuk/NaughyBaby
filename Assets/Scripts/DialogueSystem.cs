using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ali.Helper.UI.Dialogue;

public class DialogueSystem : LocalSingleton<DialogueSystem>
{
    public static int ScenarioIndex = 0;
    private AnimationType currentAnimationType;
    public static void SetScenarioIndex(int index)
    {
        ScenarioIndex = index;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(ForthScenarioProcess());
        }
    }
    IEnumerator Start()
    {
        yield return new WaitForSeconds(.1f);
        switch (ScenarioIndex)
        {
            //first olarak değiştir.
            case 0:
                yield return FirstScenarioProcess();
                break;
            //case 1:
            //    yield return HungryScenarioProcess();
            //    break;
            //case 2:
            //    yield return NeedFireScenarioProcess();
            //    break;
            //case 3:
            //    yield return CookFishScenarioProcess();
            //    break;
            //case 4:
            //    yield return AteFishScenarioProcess();
            //    break;
            //case 5:
            //    yield return AfterRabbitScenarioProcess();
            //    break;
            default:
                yield return null;
                break;
        }


    }

    //rain
    IEnumerator FirstScenarioProcess()
    {
        yield return new WaitForSeconds(1.58f);
        yield return DialogueManager.Instance.ShowQuestion("What are you going to do?", 0, "Cry and get attention", "Just sit...");
        //yield return DialogueManager.Instance.ShowQuestion("Where am I?", 0, "Ask", "Escape");
        //yield return DialogueManager.Instance.ShowQuestion("Am I in trouble?", 0, "Figure out", "Sneak out");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            yield return new WaitForSeconds(0.3f);
            GameManager.Instance.PlayerCry();
            PersonOne.Instance.HumanTurn(0);
            PersonTwo.Instance.HumanTurn(0);
            yield return new WaitForSeconds(1);
            PersonOne.Instance.Walking(-1.7f);
            PersonTwo.Instance.Walking(-1.7f);
            yield return new WaitForSeconds(1);
            PersonOne.Instance.HumanTurn(-90);
            PersonTwo.Instance.HumanTurn(90);
            yield return new WaitForSeconds(1);
            PersonOne.Instance.ParentSitting();
            PersonTwo.Instance.ParentSitting();
            yield return new WaitForSeconds(1);
            GameManager.Instance.CameraFieldOfView(32, 28);
            GameManager.Instance.CameraZoom(new Vector3(-3.55f, 4.47f, 5.47f));
            StartCoroutine(CryScenarioProcess());
        }
        else
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(FirstScenarioProcess());
        }
    }


    public void KickProcess()
    {
        StartCoroutine(CryScenarioProcess());
    }

    IEnumerator CryScenarioProcess()
    {
        yield return DialogueManager.Instance.ShowQuestion("What are you going to do?", 0, "Stop Crying.", "Go on crying");
        // yield return DialogueManager.Instance.ShowQuestion("You're about to lose your chance!", 0, "Beg", "Kick the man");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            yield return new WaitForSeconds(0.3f);
            GameManager.Instance.PlayerIdleSitting();
            yield return new WaitForSeconds(1f);
            PersonOne.Instance.PersonStandingUp();
            PersonTwo.Instance.PersonStandingUp();
            yield return new WaitForSeconds(1.8f);
            PersonOne.Instance.HumanTurn(180);
            PersonTwo.Instance.HumanTurn(180);
            yield return new WaitForSeconds(1);
            PersonOne.Instance.Walking(-10.7f);
            PersonTwo.Instance.Walking(-12.7f);
            GameManager.Instance.CameraFieldOfView(60,15);
            GameManager.Instance.CameraZoom(new Vector3(-3.55f, 3.15f, 6.17f));
            yield return new WaitForSeconds(1);
            PersonOne.Instance.HumanTurn(-90);
            PersonTwo.Instance.HumanTurn(90);
            yield return new WaitForSeconds(1);
            PersonOne.Instance.Talking();
            PersonTwo.Instance.Talking();
            StartCoroutine(FirstScenarioProcess());
        }
        else
        {
            GameManager.Instance.PlayerLieCry();
            yield return new WaitForSeconds(1f);
            StartCoroutine(SecondScenarioProcess());
        }
    }
    IEnumerator SecondScenarioProcess()
    {
        yield return DialogueManager.Instance.ShowQuestion("Are you bored? Would you like to play with your friend?", 0, "Yes", "No");
        // yield return DialogueManager.Instance.ShowQuestion("You're about to lose your chance!", 0, "Beg", "Kick the man");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            yield return new WaitForSeconds(1);
            GameManager.Instance.PlayerLieCrawl();
            yield return new WaitForSeconds(1);
            GameManager.Instance.PlayerCrawlTurn90();

            yield return new WaitForSeconds(1f);
            GameManager.Instance.PlayerHappyStanding();
            yield return new WaitForSeconds(1);
            GameManager.Instance.CameraSwitchFade();
            GameManager.Instance.CameraFieldOfView(30, 30, 270);
            yield return new WaitForSeconds(1);
            PersonOne.Instance.PersonStandingUp();
            PersonTwo.Instance.PersonStandingUp();
            StartCoroutine(ThirdScenarioProcess());
        }
        else
        {
            yield return new WaitForSeconds(0.3f);
            GameManager.Instance.PlayerLieCrawl();
            yield return new WaitForSeconds(1);
            GameManager.Instance.PlayerCrawlTurn90();
            yield return new WaitForSeconds(1);
            GameManager.Instance.PlayerCrawlSit();
            yield return new WaitForSeconds(1);
            GameManager.Instance.PlayerSadSitting();
            yield return new WaitForSeconds(1);
            StartCoroutine(SecondScenarioProcess());
        }
    }
    IEnumerator ThirdScenarioProcess()
    {
        yield return DialogueManager.Instance.ShowQuestion("What do you want to do?", 0, "Play with friend", "Throw an object to your friend");
        // yield return DialogueManager.Instance.ShowQuestion("You're about to lose your chance!", 0, "Beg", "Kick the man");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            GameManager.Instance.PlayerHappyStanding();
            yield return new WaitForSeconds(1);
            GameManager.Instance.PlayerUpSitting();
            yield return new WaitForSeconds(1);
            GameManager.Instance.SitIdleHappy();
            yield return new WaitForSeconds(1);
            StartCoroutine(ThirdScenarioProcess());
        }
        else
        {
            yield return new WaitForSeconds(1);
            GameManager.Instance.PlayerThrowObject();
            yield return new WaitForSeconds(1);
            GameManager.Instance.PlayerHappyStanding();
            GameManager.Instance.Cry();
            yield return new WaitForSeconds(3);
            StartCoroutine(ThirdOneScenarioProcess());
        }
    }
    IEnumerator ThirdOneScenarioProcess()
    {
        yield return DialogueManager.Instance.ShowQuestion("Will you say sorry to your friend?", 0, "Yes.", "No way!");
        // yield return DialogueManager.Instance.ShowQuestion("You're about to lose your chance!", 0, "Beg", "Kick the man");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            GameManager.Instance.PlayerHappyStanding();
            yield return new WaitForSeconds(1);
            GameManager.Instance.PlayerUpSitting();
            yield return new WaitForSeconds(1);
            GameManager.Instance.SitIdleHappy();
            yield return new WaitForSeconds(1);
            GameManager.Instance.IdleSit2();
            yield return new WaitForSeconds(1);
            StartCoroutine(FoodScenarioProcess());
        }
        else
        {
            //yield return new WaitForSeconds(0.3f);
            //GameManager.Instance.PlayerLieCrawl();
            //yield return new WaitForSeconds(1);
            //GameManager.Instance.PlayerCrawlSit();
            //yield return new WaitForSeconds(1);
            //GameManager.Instance.PlayerSadSitting();
            yield return new WaitForSeconds(1);
            StartCoroutine(ThirdThreeScenarioProcess());
        }
    }


    IEnumerator FoodScenarioProcess()
    {
        yield return DialogueManager.Instance.ShowQuestion("Are you hungry?", 0, "Yes!", "No I will play here.");
        // yield return DialogueManager.Instance.ShowQuestion("You're about to lose your chance!", 0, "Beg", "Kick the man");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            GameManager.Instance.PrepareFoodScenario();
            PersonOne.Instance.Relocate();
            PersonTwo.Instance.Relocate();
            GameManager.Instance.CameraFieldOfView(60, 35, 182);
            PersonOne.Instance.ManChairSitting();
            PersonTwo.Instance.ManChairSitting();
            yield return new WaitForSeconds(2);
            StartCoroutine(ForthScenarioProcess());
        }
        else
        {
            yield return new WaitForSeconds(0.3f);
            GameManager.Instance.PlayerLieCrawl();
            yield return new WaitForSeconds(1);
            GameManager.Instance.PlayerCrawlSit();
            yield return new WaitForSeconds(1);
            GameManager.Instance.SitIdleHappy();
            yield return new WaitForSeconds(1);
            StartCoroutine(FoodScenarioProcess());
        }
    }


    IEnumerator ThirdThreeScenarioProcess()
    {
        yield return DialogueManager.Instance.ShowQuestion("Soon your parent will hear and mad at you! Say sorry", 0, "Ok!.", "No way!");
        // yield return DialogueManager.Instance.ShowQuestion("You're about to lose your chance!", 0, "Beg", "Kick the man");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            GameManager.Instance.PlayerHappyStanding();
            yield return new WaitForSeconds(2);
            GameManager.Instance.PlayerUpSitting();
            yield return new WaitForSeconds(1);
            GameManager.Instance.SitIdleHappy();
            yield return new WaitForSeconds(1);
            GameManager.Instance.IdleSit2();
            yield return new WaitForSeconds(3);
            StartCoroutine(FoodScenarioProcess());
        }
        else
        {
            //yield return new WaitForSeconds(0.3f);
            //GameManager.Instance.PlayerLieCrawl();
            //yield return new WaitForSeconds(1);
            //GameManager.Instance.PlayerCrawlSit();
            //yield return new WaitForSeconds(1);
            //GameManager.Instance.PlayerSadSitting();
            //yield return new WaitForSeconds(1);
            StartCoroutine(ThirdThreeScenarioProcess());
        }
    }

    IEnumerator ForthScenarioProcess()
    {
        yield return DialogueManager.Instance.ShowQuestion("Will you eat your meal?", 0, "No! Let's make some mess", "Be good boy and have your meal");
        // yield return DialogueManager.Instance.ShowQuestion("You're about to lose your chance!", 0, "Beg", "Kick the man");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            yield return new WaitForSeconds(1);
            GameManager.Instance.HitObject();
            yield return new WaitForSeconds(2);
            GameManager.Instance.Lauging();
            yield return new WaitForSeconds(1);
            PersonOne.Instance.ManDisbelief();
            StartCoroutine(FifthScenarioProcess());
        }
        else
        {
            yield return new WaitForSeconds(1);
            GameManager.Instance.PlayerUpSitting();
            yield return new WaitForSeconds(1);
            GameManager.Instance.PlayerIdleSitting();
            yield return new WaitForSeconds(1);
            StartCoroutine(ForthScenarioProcess());
        }
    }

    IEnumerator FifthScenarioProcess()
    {
        yield return DialogueManager.Instance.ShowQuestion("MOM: Can you please stop it?", 0, "No! ", "OK. Sorry.");
        // yield return DialogueManager.Instance.ShowQuestion("You're about to lose your chance!", 0, "Beg", "Kick the man");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            yield return new WaitForSeconds(1);
            GameManager.Instance.Jumping();
            yield return new WaitForSeconds(4);
            StartCoroutine(FifthScenarioProcess());
        }
        else
        {
            yield return new WaitForSeconds(1);
            GameManager.Instance.PlayerUpSitting();
            yield return new WaitForSeconds(1);
            GameManager.Instance.PlayerSadSitting();
            yield return new WaitForSeconds(1);
            PersonOne.Instance.ManChairSitting();
            //StartCoroutine(FifthScenarioProcess());
        }
    }



}
