using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //links to the game objects to update
    public GameObject chairRight;
    public GameObject chairLeft;
    public GameObject guestOneSmall;
    public GameObject guestOneLarge;
    public GameObject guestTwoSmall;
    public GameObject guestTwoLarge;

    //set to accessible externally
    public static GameManager instance;

    private void Awake()
    {
        //ensure link to instance is itself
        instance = this;
    }

    public void RenderGuestOne() {
        chairRight.SetActive(false);
        guestOneSmall.SetActive(true);
        guestOneLarge.SetActive(true);
    }

    public void RenderGuestTwo()
    {
        chairLeft.SetActive(false);
        guestTwoSmall.SetActive(true);
        guestTwoLarge.SetActive(true);
    }
}
