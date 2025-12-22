using UnityEngine;
using TMPro; // Required for TextMeshPro

public class WalletUI : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI totalCoinsText;

    void Start()
    {
        UpdateWalletDisplay();
    }

    // You can call this function again if the player buys something 
    // to refresh the number on screen!
    public void UpdateWalletDisplay()
    {
        if (totalCoinsText != null)
        {
            // We use the static LoadTotalCoins method from your CurrencyHandler
            int total = CurrencyHandler.LoadTotalCoins();
            totalCoinsText.text = "Total Coins: " + total.ToString();
        }
    }
}