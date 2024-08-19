using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Ghost worker;
    public Ghost trap;
    public Ghost village;
    public Ghost crystal;
    public Ghost wood;
    public AudioSource clickSound;

    ShopButton shopButton;
    public void OnShopClick(string ghostType)
    {
        Instantiate(clickSound);
        switch (ghostType)
        {
            case "village":
                Instantiate(village);
                break;
            case "wood":
                Instantiate(wood);
                break;
            case "crystal":
                Instantiate(crystal);
                break;
            case "worker":
                Instantiate(worker);
                break;
            case "trap":
                Instantiate(trap);
                break;
        }
    }
}
