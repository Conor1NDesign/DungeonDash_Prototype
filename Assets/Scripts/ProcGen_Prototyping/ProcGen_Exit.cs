using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcGen_Exit : MonoBehaviour
{
    private bool winnerDecided = false;

    private GameObject winTextUI;
    private GameObject winnerNameUI;


    public void Awake()
    {
        winTextUI = GameObject.Find("WinnerText");
        if (winTextUI == null)
            Debug.LogError("There is no UI object named WinnerText in the gameplay scene, please add one! (Ask Conor for more details)");
        else
            winTextUI.SetActive(false);
        
        winnerNameUI = GameObject.Find("WinnerName");
        if (winnerNameUI == null)
            Debug.LogError("There is no UI object named WinnerName in the gameplay scene, please add one! (Ask Conor for more details)");
        else
            winnerNameUI.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !winnerDecided)
        {
            DetermineWinner(other.gameObject);
        }
    }

    public void DetermineWinner(GameObject winner)
    {
        winnerDecided = true;
        string nameOfWinner = winner.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
        winTextUI.SetActive(true);
        winnerNameUI.SetActive(true);

        winnerNameUI.GetComponent<TMPro.TextMeshProUGUI>().text = nameOfWinner;
    }
}
