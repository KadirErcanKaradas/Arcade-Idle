using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;
    public void ChangeMoneyText(int moneyValue)
    {
        moneyText.text = moneyValue.ToString();
    }
    
}
