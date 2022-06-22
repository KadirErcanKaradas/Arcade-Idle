using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankB : MonoBehaviour
{
    [SerializeField] public List<GameObject> money = new List<GameObject>();
    [SerializeField] private bool isCollect = false;
    [SerializeField] public GameObject moneyPivot;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollect = true;
            GameManager.instance.Drop(this);
            print("asdf");

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollect = false;
            GameManager.instance.StopDrop();
        }
    }

  
}
