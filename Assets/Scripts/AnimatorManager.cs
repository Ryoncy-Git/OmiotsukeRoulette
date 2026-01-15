using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField]private GameObject managers;
    private Yomikata candidate;
    static RouletteManager rouletteManager;
    static UIManager uiManager;
    private Animator animator;
    private int yomikataSize = 6;

    void Start()
    {
        rouletteManager = managers.GetComponent<RouletteManager>();
        animator = this.gameObject.GetComponent<Animator>();
        uiManager = managers.GetComponent<UIManager>();
    }

    public void ShowNextCandidate(int num)
    {
        candidate = (Yomikata)(((int)candidate + 1) % yomikataSize);

        for (int i = num; i < 3; i++) // result.length = 3
        {   
            uiManager.SetTextYomikataDummy(candidate, i);
        }
    }

    public void StopSlot(int i)
    {
        switch(i)
        {
            case 0:
            animator.SetTrigger("Stop-0");
            break;

            case 1:
            animator.SetTrigger("Stop-1");
            break;

            case 2:
            animator.SetTrigger("Stop-2");
            break;

            default:
            break;
        }
    }

    public void StartRoulette()
    {
        animator.SetTrigger("Start");
    }

    public void StopRoulette()
    {
        // animator.SetTrigger("Stop-1");
    }

    public void EmptyFunction()
    {
        
    }
}
