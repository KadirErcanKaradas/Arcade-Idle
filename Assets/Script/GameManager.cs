using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private PlayerManager playerManager;
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
    public void Drop(BankB bankB)
    {
        playerManager.MoneyDrop(bankB);
    }
    public void StopDrop()
    {
        playerManager.StopDrop();
    }
}
