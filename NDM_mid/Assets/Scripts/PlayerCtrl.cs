using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCtrl : MonoBehaviour
{
    private CharacterController controller;
    private new Transform transform;
    private Animator anim;
    Vector3 moveVec;
    public float moveSpeed = 10.0f;
    public int coin;
    public TextMeshProUGUI coinUI;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        transform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        //coinUI = GameObject.FindGameObjectWithTag("CoinNum")?.GetComponent<TextMeshProUGUI>();

        coin = 0;
    }

    void Update()
    {
        Move();
        Turn();
        if(coin >= 0)
        {
            coinUI.text = "$ " + coin;
        }
    }

    float hAxis => Input.GetAxis("Horizontal");
    float vAxis => Input.GetAxis("Vertical");

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        
        transform.position += moveVec*moveSpeed*Time.deltaTime;
        
        anim.SetBool("isWalk", hAxis != 0.0f || vAxis != 0.0f);
    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "BRONZECOIN")
        {
            coin = coin + 2;
            Destroy(coll.gameObject);
        }
        else if(coll.tag == "SILVERCOIN")
        {
            coin = coin + 5;
            Destroy(coll.gameObject);
        }
        if(coll.tag == "GOLDCOIN")
        {
            coin = coin + 7;
            Destroy(coll.gameObject);
        }
    }

    public void UseCoin(int num)
    {
        coin = coin - num;
    }
}
