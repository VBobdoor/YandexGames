using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Yandex : MonoBehaviour
{
    [SerializeField] Text text;
   // [DllImport("__Internal")]
   // private static extern void AddCoinsExtern();

   // [DllImport("__Internal")]
   // private static extern void Hello();

    private void Awake()
    {
        //Hello();
    }
    public void HelloButton()
    {
       // AddCoinsExtern();  
    }
    public void advShowed()
    {
        text.text = "hello there";
        //myGameInstance.SendMessage("CoinManager", "AddCoins", value);
    }
}
