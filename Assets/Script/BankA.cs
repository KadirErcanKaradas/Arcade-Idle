using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BankA : MonoBehaviour
{
    [SerializeField] public List<GameObject> money = new List<GameObject>();
    [SerializeField] private bool isCollect = false;
    [SerializeField] private GameObject moneyPreb;
    [SerializeField] private GameObject exitPoint;
    [SerializeField] private GameObject moneyParent;
    private int stackCount = 10;
    private bool isWorking = false;

    private void Start()
    {
        StartCoroutine(MoneyCreate());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollect = true;
            StartCoroutine(MoneyCollect());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollect = false;
        }
    }
    IEnumerator MoneyCollect()
    {
        while (isCollect)
        {
            if (money.Count>0)
            {
                GameManager.instance.Collect(money[money.Count - 1], this);
            }
            yield return new WaitForSeconds(0.25f);
        }

    }
    IEnumerator MoneyCreate()
    {
        while (true)
        {
            int rowCount = (int)money.Count / stackCount;
            if (isWorking == true)
            {
                GameObject temp = Instantiate(moneyPreb);
                money.Add(temp);
                temp.transform.position = new Vector3(exitPoint.transform.position.x + money.Count / 50 * -1, (money.Count % stackCount) * 0.1f, exitPoint.transform.position.z + ((money.Count%50) / -10));
                temp.transform.parent = moneyParent.transform;
                if (money.Count >= 100)
                {
                    isWorking = false;
                }
            }
            else if (money.Count <= 100)
            {
                isWorking = true;
            }
            yield return new WaitForSeconds(0.5f);
        }

    }
}
