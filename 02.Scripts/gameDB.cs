using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameDB : MonoBehaviour {

    public static gameDB SingletonInstance = null;

    public static gameDB Singleton()
    {
        if(! SingletonInstance)
        {
            GameObject TempSingletonInstance = new GameObject();
            SingletonInstance = TempSingletonInstance.AddComponent<gameDB>();
            SingletonInstance.name = typeof(gameDB).ToString();

            DontDestroyOnLoad(SingletonInstance);
        }
        return SingletonInstance;
    }

    public PlayerData NowPlayerData = new PlayerData();

    /*[System.Serializable]
    public class ItemData
    {
        public string ItemName;
        public int ItemNumber;
    }*/

    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
        public int maxScore1;
        public int maxScore2;
        public int maxScore3;
        public int maxScore4;
        public int maxScore5;
        public bool isUsing;

        public int Stage1Star;
        public int Stage2Star;
        public int Stage3Star;
        public int Stage4Star;
        public int Stage5Star;

        public int CoinQuantity;
        public int RainbowQuantity;
        public int SOSQuantity;
        //public List<ItemData> Inventory = new List<ItemData>();
    }
}