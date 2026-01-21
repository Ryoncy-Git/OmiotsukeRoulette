using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    static RouletteManager rouletteManager;
    static UIManager uiManager;
    [SerializeField] private Animator animator;

    void Start()
    {
        rouletteManager = this.gameObject.GetComponent<RouletteManager>();
        uiManager = this.gameObject.GetComponent<UIManager>();
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

        animator.SetTrigger("PushCamera");
    }

    public void StartRoulette()
    {
        animator.SetTrigger("Start");
    }

    public void StopRoulette()
    {
        // animator.SetTrigger("Stop-1");
    }

    public void ShowResult()
    {
        animator.SetTrigger("Result");
    }
    
}
