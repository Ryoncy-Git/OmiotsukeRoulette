using UnityEngine;
using System.Collections;
public enum Yomikata
{
    o = 1,
    on = 2,
    go = 3,
    gyo = 4,
    mi = 5,
};

public class RouletteManager : MonoBehaviour
{
    //Object 
    [SerializeField] private GameObject UIs;

    // instaces
    static UIManager uiManager;
    static AnimatorManager animatorManager;

    // variants
    Yomikata[] result = new Yomikata[3];
    bool isRolling = false;

    void Start()
    {
        uiManager = this.gameObject.GetComponent<UIManager>();
        animatorManager = UIs.GetComponent<AnimatorManager>();
    }

    public void CLickRouletteButton()
    {
        // ルーレットボタンをクリック
        // 乱数を取得
        for(int i = 0; i < result.Length; i++)
        {
            result[i] = (Yomikata)Random.Range(0, 6); // 6 == Yomikata.Length
        }        

        // アニメーションを再
        animatorManager.StartRoulette();

        // ルーレットボタンを無効化
        uiManager.HideRouletteButton();
    }

    public void OnRollingEnd()
    {
        // 表示
        for(int i = 0; i < result.Length; i++)
        {
            Yomikata r = result[i];

            switch(r)
            {
                case Yomikata.o:
                uiManager.SetText("お", i); // いったん一つ目のテキストだけ編集
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

        uiManager.ShowRouletteButton();

    }
}
