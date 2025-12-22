using UnityEngine;

public static class CurrencyHandler
{
    private const string COIN_KEY = "TotalCoins";

    // Saves a specific value to PlayerPrefs
    public static void SaveTotalCoins(int amount)
    {
        PlayerPrefs.SetInt(COIN_KEY, amount);
        PlayerPrefs.Save();
        Debug.Log("Coins Saved: " + amount);
    }

    // Loads the value from PlayerPrefs
    public static int LoadTotalCoins()
    {
        return PlayerPrefs.GetInt(COIN_KEY, 0);
    }

    // Optional: Use this to "spend" coins in the shop
    public static void SubtractCoins(int cost)
    {
        int currentBalance = LoadTotalCoins();
        if (currentBalance >= cost)
        {
            SaveTotalCoins(currentBalance - cost);
        }
    }
}