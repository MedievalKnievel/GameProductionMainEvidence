using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public GameObject CustomNM, winObj, Win, Lose, WinSpin, Hbutton, Jbutton;
    private CustomNetworkManager cNm;
    private WinConScript winScript;
    public float timeNo = 30;
    public float spinSpeed = 10000f;
    public TextMeshProUGUI text;

    void Start()
    {
        Win.SetActive(false);
        Lose.SetActive(false);
        cNm = CustomNM.GetComponent<CustomNetworkManager>();
        winScript = winObj.GetComponent<WinConScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cNm.secondPlayerJoined)
        {
            timeNo -= Time.deltaTime;
            text.text = Mathf.Round(timeNo).ToString();
            print("Time left: " + Mathf.Round(timeNo));

            if(winScript.win)
            {
                timeNo = 0;
                Win.SetActive(true);
                winScript.gameOver = true;
                WinSpin.transform.rotation = Quaternion.Euler(0, (spinSpeed * timeNo) * 100, (spinSpeed * timeNo) * 100);
            } else if(timeNo < 0 && !winScript.win)
            {
                timeNo = 0;
                Lose.SetActive(true);
                winScript.gameOver = true;
            }

        }
    }

    public void DisableButton()
    {
        print("buttons should be disabled");
        Hbutton.SetActive(false);
        Jbutton.SetActive(false);
    }
}
