using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

[RequireComponent(typeof(NavMeshAgent))]


public class Knight_player : MonoBehaviour
{
    public GameObject player;
    private Transform pTransform;
    private NavMeshAgent myNavMeshAgent;
    Vector3 tar;
    bool isEmpty = false;
    public int Id;
    Vector3 tempkonum;
    public GameObject dolu;
    bool isMove = false;
  

    private bool isSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        pTransform = GetComponent<Transform>();
        Debug.Log(transform.position);
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        GameManager.Instance.name = true;
        tempkonum = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButtonDown(0) && isSelected)
            {
                ClickToMove();
                
            }
        

        if (GameManager.Instance.list[Id]==false)
        {
            isSelected = false;
            myNavMeshAgent.baseOffset = 0f;
        }
    
    }

   
     private void ClickToMove()
    {
       
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);

        if (hit.collider.gameObject.CompareTag("tas"))
        {
            isEmpty = true;
           
        }

        if (hit.collider.gameObject.CompareTag("ok"))
        {
            isEmpty = true;
            isSelected = false;
            myNavMeshAgent.baseOffset = 0f;
        }



        if (hit.collider.gameObject.CompareTag("alan") && isEmpty==false)
        {
            if (hasHit)
            {
                SetDestination(hit.point);
                Debug.Log(transform.position);
                
                isSelected = false;
                myNavMeshAgent.baseOffset = 0f;

            }
        }
        isMove = false;
    }

    private void SetDestination(Vector3 target)
    {
        if ((0.50 < target.x) && (target.x < 1.50)){
            target.x = 1;
        }
        else if ((-0.50 < target.x) && (target.x < 0.50))
        {
            target.x = 0;
        }
        else if ((1.50 < target.x) && (target.x < 2.50)){
            target.x = 2;
        }
        else if ((2.50 < target.x) && (target.x < 3.50)){
            target.x = 3;
        }
        else if ((3.50 < target.x) && (target.x < 4.50)){
            target.x = 4;
        }
        else if ((4.50 < target.x) && (target.x < 5.50))
        {
            target.x = 5;
        }

        if ((0.50 < target.z) && (target.z < 1.50))
        {
            target.z = 1;
        }
        else if ((-0.50 < target.z) && (target.z < 0.50))
        {
            target.z = 0;
        }
        else if ((1.50 < target.z) && (target.z < 2.50))
        {
            target.z = 2;
        }
        else if ((2.50 < target.z) && (target.z < 3.50))
        {
            target.z = 3;
        }
        else if ((3.50 < target.z) && (target.z < 4.50))
        {
            target.z = 4;
        }
        else if ((4.50 < target.z) && (target.z < 5.50))
        {
            target.z = 5;
        }


        if ((target.x - transform.position.x == -1) && (target.z - transform.position.z == +2))
        {
            myNavMeshAgent.SetDestination(target);
            isMove = true;
            tar = target;
        }
        
        if ((target.x - transform.position.x == -2) && (target.z - transform.position.z == +1))
        {
            myNavMeshAgent.SetDestination(target);
            isMove = true;
            tar = target;
        }

        if ((target.x - transform.position.x == +1) && (target.z - transform.position.z == +2))
        {
            myNavMeshAgent.SetDestination(target);
            isMove = true;
            tar = target;
        }

        if ((target.x - transform.position.x == +2) && (target.z - transform.position.z == +1))
        {
            myNavMeshAgent.SetDestination(target);
            isMove = true;
            tar = target;
        }

        if ((target.x - transform.position.x == -1) && (target.z - transform.position.z == -2))
        {
            myNavMeshAgent.SetDestination(target);
            isMove = true;
            tar = target;
        }

        if ((target.x - transform.position.x == -2) && (target.z - transform.position.z == -1))
        {
            myNavMeshAgent.SetDestination(target);
            isMove = true;
            tar = target;
        }

        if ((target.x - transform.position.x == +1) && (target.z - transform.position.z == -2))
        {
            myNavMeshAgent.SetDestination(target);
            isMove = true;
            tar = target;
        }

        if ((target.x - transform.position.x == +2) && (target.z - transform.position.z == -1))
        {
            myNavMeshAgent.SetDestination(target);
            isMove = true;
            tar = target;
        }

        Debug.Log(isMove);
        
        
        if (isMove==true )
        {
            Instantiate(dolu, new Vector3(tempkonum.x, tempkonum.y + 5f, tempkonum.z), transform.rotation);
            tempkonum = tar;
        }
        
    }

    private void OnMouseDown()
    {
        GameManager.Instance.ChooseSelected(Id);

        if (isSelected==false && GameManager.Instance.list[Id])
        {
            isSelected = true;
            myNavMeshAgent.baseOffset = 0.75f;
            isEmpty = false;
            
        }
        else
        {
            isSelected = false;
            myNavMeshAgent.baseOffset = 0f;
            
        }

        
    }

    private void Finish()
    {
        GameManager.Instance.NextLevel();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bitis"))
        {
            Debug.Log("bittii");

            Invoke("Finish", 0.8f);
        }
    }
}
// myNavMeshAgent.SetDestination(target);

// Up / Left                                         
//KnightMove(CurrentX - 1, Currentz + 2, ref r);
//KnightMove(CurrentX - 2, Currentz + 1, ref r);

//// Up / Right
//KnightMove(CurrentX + 1, Currentz + 2, ref r);
//KnightMove(CurrentX + 2, Currentz + 1, ref r);

//// Down / Left
//KnightMove(CurrentX - 1, Currentz - 2, ref r);
//KnightMove(CurrentX - 2, Currentz - 1, ref r);

//// Down / Right
//KnightMove(CurrentX + 1, Currentz - 2, ref r);
//KnightMove(CurrentX + 2, Currentz - 1, ref r);
