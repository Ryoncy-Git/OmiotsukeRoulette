using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField]private GameObject managers;
    Yomikata candidate;
    static RouletteManager rouletteManager;
    static UIManager uiManager;
    Animator animator;
    private int yomikataSize = 6;

    void Start()
    {
        rouletteManager = managers.GetComponent<RouletteManager>();
        animator = this.gameObject.GetComponent<Animator>();
        uiManager = managers.GetComponent<UIManager>();
    }

    public void StartRoulette()
    {
        animator.SetTrigger("Start");
    }

    public void ShowNextCandidate()
    {
        candidate = (Yomikata)(((int)candidate + 1) % yomikataSize);
        for (int i = 0; i < 3; i++) // 3 == num of text
        {
            switch(candidate)
            {
                case Yomikata.o:
                uiManager.SetText("お", i);
                break;

                case Yomikata.on:
                uiManager.SetText("おん", i);
                break;

                case Yomikata.go:
                uiManager.SetText("ご", i);
                break;

                case Yomikata.gyo:
                uiManager.SetText("ぎょ", i);
                break;

                case Yomikata.mi:
                uiManager.SetText("み", i);
                break;
            }
        }
        
    }

    public void StopRoulette()
    {
        animator.SetTrigger("Stop");
        rouletteManager.OnRollingEnd();
    }
}
