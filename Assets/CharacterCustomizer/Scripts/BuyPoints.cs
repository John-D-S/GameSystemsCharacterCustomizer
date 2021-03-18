using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyPoints : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI bankText;
    [SerializeField]
    private List<TextMeshProUGUI> statTexts;

    [SerializeField]
    private int statBank = 10;
    [System.NonSerialized]
    public List<int> statValues = new List<int>();

    public PlayerControler player;

    private void Start()
    {

        for (int i = 0; i < statTexts.Count; i++)
        {
            statValues.Add(0);
            statTexts[i].text = "0";
            Debug.Log(i);
        }
        bankText.text = statBank.ToString();
    }

    public void RaiseStat(int value)
    {
        if (statBank <= 0)//do nothing if there are no points left in the bank
            return;
        statBank--;
        bankText.text = statBank.ToString();
        statValues[value]++;
        statTexts[value].text = statValues[value].ToString();
    }

    public void LowerStat(int value)
    {
        if (statValues[value] <= 0)
            return;
        statValues[value]--;//reduce the value for this stat
        statTexts[value].text = statValues[value].ToString(); //update the stat's text
        statBank++;//increase the value for the stat bank
        bankText.text = statBank.ToString();//update the bank's text
    }

    public void confirmStats(PlayerControler player)
    {
        if (statBank == 0)
        {
            for (int i = 0; i < statValues.Count; i++)
            {
                for (int j = 0; j < statValues[i]; j++)
                {
                    player.raiseStat(i + 1);
                }
            }
            gameObject.SetActive(false);
        }
    }
}
