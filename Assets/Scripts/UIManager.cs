using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private RouletteManager rouletteManager;
    private AudioManager audioManager;
    private AnimatorManager animatorManager;
    [SerializeField] private TextMeshProUGUI[] text;
    [SerializeField] private TextMeshProUGUI[] dummys;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject inMenuObject;
    [SerializeField] private GameObject inEndRoulette;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject Audio;


    void Start()
    {
        rouletteManager = this.gameObject.GetComponent<RouletteManager>();
        audioManager = Audio.gameObject.GetComponent<AudioManager>();
        animatorManager = this.gameObject.GetComponent<AnimatorManager>();

        inMenuObject.SetActive(false);
        inEndRoulette.SetActive(false);
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

    public void SetTextYomikataDummy(Yomikata yomi, int num)     
    {
        
        // early return
        if(dummys == null) return;
        if(num < 0 || num >= dummys.Length) return;
        if(dummys[num] == null) return;

        switch(yomi)
        {
            case Yomikata.o:
            dummys[num].text = "お";
            break;

            case Yomikata.on:
            dummys[num].text = "おん";
            break;

            case Yomikata.go:
            dummys[num].text = "ご";
            break;

            case Yomikata.gyo:
            dummys[num].text = "ぎょ";
            break;

            case Yomikata.mi:
            dummys[num].text = "み";
            break;

            default:
            break;
        }
    }

    public void HideDummys(int i)
    {
        dummys[i].gameObject.SetActive(false);
        text[i].gameObject.SetActive(true);  
    }

    public void ShowDummys(int i)
    {
        dummys[i].gameObject.SetActive(true);
        text[i].gameObject.SetActive(false); 
    }

    public void ClickRouletteButton()
    {
        rouletteManager.StartRoulette();
    }


    public void HideRouletteButton()
    {
        startButton.SetActive(false);
    }

    public void ShowRouletteButton()
    {
        startButton.SetActive(true);
    }

    public void ShowSpecificCondition(SpecificCondition condition)
    {
        switch(condition)
        {
            case SpecificCondition.Omiotsuke:
            Debug.Log("-----------omiotsuke");
            break;

            case SpecificCondition.Sakanakun:
            Debug.Log("-------------sakanakun");
            break;

            case SpecificCondition.Ear:     
            Debug.Log("---------------ear");
            break;
            
            case SpecificCondition.Zorome:
            Debug.Log("---------------zorome");
            break;

            default:
            break;
        }
    }

    public void ClickMenuButton(bool status)
    {
        inMenuObject.SetActive(status);
    }

    public void ChangeMasterVolume()
    {
        audioManager.ChangeMasterVolume(slider.value);
    }

    public void ShowResult()
    {
        inEndRoulette.SetActive(true);
    }
}
