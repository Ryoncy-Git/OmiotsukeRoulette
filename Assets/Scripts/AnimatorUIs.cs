using UnityEngine;

public class AnimatorUIs : MonoBehaviour
{
    // 今思うとAnimatorRecieverとかって名前つけたほうが良かったかも
    [SerializeField] private UIManager uiManager;
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
}
