using UnityEngine;

public class AnimatorReciever : MonoBehaviour
{
    // 今思うとAnimatorRecieverとかって名前つけたほうが良かったかも
    [SerializeField] private UIManager uiManager;
    [SerializeField] private AudioManager audioManager;
    private Yomikata candidate;

    public void EmptyFunction()
    {
        
    }

    public void ShowNextCandidate(int num)
    {
        candidate = (Yomikata)(((int)candidate + 1) % 6); // 6 == yomikata.size

        for (int i = num; i < 3; i++) // result.length = 3
        {   
            uiManager.SetTextYomikataDummy(candidate, i);
        }
    }      

    public void PlaySEResult()
    {
        audioManager.PlaySEResult();
    }


    public void ShowResult()
    {
        uiManager.ShowResult();
    }

    public void HideResult()
    {
        uiManager.HideResult();
    }
}
