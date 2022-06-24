using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class BankB : MonoBehaviour
{
    [SerializeField] public List<GameObject> money = new List<GameObject>();
    [SerializeField] private bool isCollect = false;
    [SerializeField] public GameObject moneyPivot;
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject takeMoney;
    [SerializeField] private int areaPrize = 200;
    [SerializeField] private GameObject moneyAreaGround;
    public bool isMachineActive = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollect = true;
            GameManager.instance.Drop(this);
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
    public void FillArea(GameObject item)
    {
        if (!isMachineActive)
        {
            int moneyArea = money.Count * 10;
            moneyText.text = moneyArea + "/" + areaPrize;
            money.Add(item);
            item.transform.parent = moneyPivot.transform;
            Vector3 direction = new Vector3(0, 0, money.Count * 1);
            item.transform.DOLocalMove(Vector3.zero, 0.25f);
            item.transform.DOLocalRotate(Vector3.zero, 0.25f);

            if (moneyArea == areaPrize)
            {
                isMachineActive = true;
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                cube.SetActive(true);
                takeMoney.SetActive(false);
                moneyAreaGround.SetActive(true);

            }
        }
       
    }
}
