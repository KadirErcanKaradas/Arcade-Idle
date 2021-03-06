using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private UIController uiController;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }
    public void Collect(GameObject item,BankA bankA)
    {
        playerManager.AddMoney(item,bankA);
        playerManager.ChangeAnimation(true);
    } 
    public void Drop(Land land)
    {
        playerManager.MoneyDrop(land);
    }
    public void StopDrop()
    {
        playerManager.StopDrop();
    }
    public void ChangeMoneyText(int moneyValue)
    {
        uiController.ChangeMoneyText(moneyValue);

    }
}
