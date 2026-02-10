using UnityEngine;
using System.Collections;

public class RouletteManager : MonoBehaviour
{
    //Object 
    [SerializeField] private GameObject UIs;
    [SerializeField] private GameObject Audio;

    // instaces
    static UIManager uiManager;
    static AnimatorManager animatorManager;
    static AudioManager audioManager;

    // variants
    private Yomikata[] result = new Yomikata[3];
    public int stopCounter {get; private set;}
    public AppState state {get; private set;}

    void Start()
    {
        uiManager = this.gameObject.GetComponent<UIManager>();
        animatorManager = this.gameObject.GetComponent<AnimatorManager>();
        audioManager = Audio.GetComponent<AudioManager>();
        state = AppState.Wait;
        stopCounter = 0;

        audioManager.PlayBGM();
    }

    public void StartRoulette()
    {
        // ルーレットボタンをクリック
        // 乱数を取得
        for(int i = 0; i < result.Length; i++)
        {
            result[i] = (Yomikata)Random.Range(1, 6); // 6 == Yomikata.Length
        }        

        // 数値の初期化
        stopCounter = 0;
        state = AppState.Roll;

        // アニメーションを再
        animatorManager.StartRoulette();

        // ルーレットボタンを無効化
        uiManager.HideRouletteButton();
        for(int i = 0; i < 3; i++)
        {
            uiManager.ShowDummys(i);
        }
    }

    public void StopNextSlot()
    {
        // 次のスロットを停止して結果を表示
        animatorManager.StopSlot(stopCounter);
        uiManager.SetTextYomikata(result[stopCounter], stopCounter);
        uiManager.HideDummys(stopCounter);
        audioManager.PlaySE(stopCounter);

        stopCounter++;


        // 3つすべて回し終わっていたら
        if(stopCounter == result.Length)
        {
            CheckSpecificCondition();
            state = AppState.End;
        }
    }

    public void ReadyForNextRoulette()
    {
        state = AppState.Wait;
        uiManager.ShowRouletteButton();
    }

    private void CheckSpecificCondition()
    {
        if (result[0] == Yomikata.o && result[1] == Yomikata.mi && result[2] == Yomikata.o)
        {
            // おみおつけ完成
            uiManager.ShowSpecificCondition(SpecificCondition.Omiotsuke);
        }
        else if(result[0] == Yomikata.gyo && result[1] == Yomikata.gyo && result[2] == Yomikata.gyo)
        {
            uiManager.ShowSpecificCondition(SpecificCondition.Sakanakun);
        }
        else if(result[0] == Yomikata.o && result[1] == Yomikata.mi && result[2] == Yomikata.mi)
        {
            uiManager.ShowSpecificCondition(SpecificCondition.Ear);
        }
        else if(result[0] == result[1] && result[1] == result[2])
        {
            uiManager.ShowSpecificCondition(SpecificCondition.Zorome);
        }

        // Debug.Log(result[0].ToString() + result[1].ToString() + result[2].ToString());
    }
}
