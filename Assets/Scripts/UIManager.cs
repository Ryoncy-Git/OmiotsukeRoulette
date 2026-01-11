using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private RouletteManager rouletteManager;
    [SerializeField] private TextMeshProUGUI[] text;
    [SerializeField] private GameObject button;


    void Start()
    {
        rouletteManager = this.gameObject.GetComponent<RouletteManager>();
    }
    
    public void SetTextYomikata(Yomikata yomi, int num)
    {
        
        // early return
        if(text == null) return;
        if(num < 0 || num >= text.Length) return;
        if(text[num] == null) return;

        switch(yomi)
        {
            case Yomikata.o:
            text[num].text = "お";
            break;

            case Yomikata.on:
            text[num].text = "おん";
            break;

            case Yomikata.go:
            text[num].text = "ご";
            break;

            case Yomikata.gyo:
            text[num].text = "ぎょ";
            break;

            case Yomikata.mi:
            text[num].text = "み";
            break;

            default:
            break;
        }
    }

    public void ClickRouletteButton()
    {
        rouletteManager.StartRoulette();
    }


    public void HideRouletteButton()
    {
        button.SetActive(false);
    }

    public void ShowRouletteButton()
    {
        button.SetActive(true);
    }

    public void ShowSpecificCondition(SpecificCondition condition)
    {
        switch(condition)
        {
            case SpecificCondition.Omiotsuke:
            Debug.Log("omiotsuke");
            break;

            case SpecificCondition.Sakanakun:
            Debug.Log("sakanakun");
            break;

            case SpecificCondition.Ear:     
            Debug.Log("ear");
            break;
            
            case SpecificCondition.Zorome:
            Debug.Log("zorome");
            break;

            default:
            break;
        }
    }
}
