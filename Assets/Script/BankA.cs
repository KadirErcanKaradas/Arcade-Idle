using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BankA : MonoBehaviour
{
    [SerializeField] public List<GameObject> money = new List<GameObject>();
    [SerializeField] private bool isCollect = false ;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollect = true ;
            StartCoroutine(MoneyCollect());

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollect= false;
        }
    }

    IEnumerator MoneyCollect()
    {
        while (money.Count > 0 && isCollect)
        {
            GameManager.instance.Collect(money[money.Count - 1],this);
            yield return new WaitForSeconds(0.25f);
        }
        
    }
}
