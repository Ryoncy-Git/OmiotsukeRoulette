using UnityEngine;
using TMPro;
using System.Security.Cryptography.X509Certificates;

public class UIManager : MonoBehaviour
{
    RouletteManager rm;
    // [SerializeField]
    [SerializeField] private TextMeshProUGUI[] text;
    [SerializeField] private GameObject button;
    void Start()
    {
        rm = this.gameObject.GetComponent<RouletteManager>();
    }
    // objects
    
    public void SetText(string str, int num)
    {
        
        // early return
        if(text == null) return;
        if(num < 0 || num >= text.Length) return;
        if(text[num] == null) return;

        text[num].text = str;
    }

    public void ClickRouletteButton()
    {
        rm.CLickRouletteButton();
    }


    public void HideRouletteButton()
    {
        button.SetActive(false);
    }

    public void ShowRouletteButton()
    {
        button.SetActive(true);
    }
}
