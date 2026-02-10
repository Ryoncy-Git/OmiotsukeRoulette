using UnityEngine;

public class InuputManager : MonoBehaviour
{
    private RouletteManager rouletteManager;

    void Start()
    {
        rouletteManager = this.gameObject.GetComponent<RouletteManager>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(rouletteManager.state == AppState.Roll)
            {
                rouletteManager.StopNextSlot();
            }
            else if (rouletteManager.state == AppState.Wait)
            {
                rouletteManager.StartRoulette();
            }
            else if(rouletteManager.state == AppState.End)
            {
                // rouletteManager.StopRoulette();
                // リザルト表示をスキップする機能を付けたい
            }
        }
    }
}
