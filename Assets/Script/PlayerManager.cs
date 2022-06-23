using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject moneyParent;
    [SerializeField] private GameObject bankParent;
    [SerializeField] public List<GameObject> money = new List<GameObject>(); 
    private int moneyPrize=0;
    private FloatingJoystick joystick;
    private Animator anim;
    private bool isStack = false;
    private Coroutine coroutine;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<FloatingJoystick>();
        anim = GetComponent<Animator>();
    }
 
    void FixedUpdate()
    {
        rb.velocity = new Vector3(joystick.Horizontal * moveForce, rb.velocity.y, joystick.Vertical * moveForce);


        if (joystick.Horizontal != 0f || joystick.Vertical != 0f)
        {
            anim.SetBool("running", true);
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
        else anim.SetBool("running", false);
    }
    public void AddMoney(GameObject item, BankA bankA)
    {
        bankA.money.Remove(item);
        money.Add(item);
        moneyPrize += 10;
        GameManager.instance.ChangeMoneyText(moneyPrize);
        item.transform.parent = moneyParent.transform;
        Vector3 direction = new Vector3(0,money.Count* 0.015f, 0);
        item.transform.DOLocalMove(direction,0.25f);
        item.transform.DOLocalRotate(Vector3.zero, 0.25f);
    }
    public void RemoveMoney(GameObject item, BankB bankB)
    {
        money.Remove(item);
        bankB.money.Add(item);
        item.transform.parent = bankParent.transform;
        Vector3 direction = new Vector3(0,0, bankB.money.Count*1);
        item.transform.DOLocalMove(bankB.moneyPivot.transform.position*2, 0.25f);
        item.transform.DOLocalRotate(Vector3.zero, 0.25f);
    }
    public void ChangeAnimation(bool isStack)
    {
            anim.SetLayerWeight(1, 0.9f); 
    }

    public void MoneyDrop(BankB bankB)
    {
        coroutine = StartCoroutine(MoneyDropDelay(bankB));
    }
    public void StopDrop()
    {
       if(coroutine != null) StopCoroutine(coroutine);
    }

    IEnumerator MoneyDropDelay(BankB bankB)
    {
        print("start");
        while (money.Count > 0 && !bankB.isMachineActive)
        {
 
            print("money");
            GameObject item = money[money.Count - 1]; 
            money.Remove(item);
            moneyPrize -= 10;
            bankB.FillArea(item);
            GameManager.instance.ChangeMoneyText(moneyPrize);
            yield return new WaitForSeconds(0.25f);
        }
            anim.SetLayerWeight(1, 0f);
    }
}
