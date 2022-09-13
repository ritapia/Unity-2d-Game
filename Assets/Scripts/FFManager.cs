using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FFManager : MonoBehaviour {

    public GameObject gameOverCanvas;
    public Image[] liveImages;
    public int livesAmount = 3;


	// Use this for initialization
	void Start ()
    {
        gameOverCanvas.SetActive(false);
    }
	
	
	void Update () {

        switch (livesAmount)
        {
            case 0:
                liveImages[0].enabled = false;
                liveImages[1].enabled = false;
                liveImages[2].enabled = false;
                gameOverCanvas.SetActive(true);
                break;
            case 1:
                liveImages[0].enabled = true;
                liveImages[1].enabled = false;
                liveImages[2].enabled = false;
                break;
            case 2:
                liveImages[0].enabled = true;
                liveImages[1].enabled = true;
                liveImages[2].enabled = false;
                break;
            case 3:
                liveImages[0].enabled = true;
                liveImages[1].enabled = true;
                liveImages[2].enabled = true;
                break;
        }

    }

}
