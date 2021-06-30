using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EngeleCarpma : MonoBehaviour
{

    
    private GameManager gameManager;
    private Rigidbody rb;
    private GameObject stackPoint;
    private GameObject stackPointt;
    public GameObject gameObjectt;
    private List<int> _oneTime = new List<int>();
    
    

    private void OnEnable()
    {
        stackPoint = GameObject.Find("SpawnPoint");
        stackPointt = GameObject.Find("spawnPoint");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }
    
    

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Block")
        {
            if (!_oneTime.Contains(1))
            {
                ShoesDestroy();
                _oneTime.Add(1);
            }
        }
    }


    private void ShoesDestroy()
    {
        if (gameManager._list.Contains(this.gameObject))
        {

            gameManager._list.Remove(this.gameObject);
            gameManager.n -= 1;
            stackPoint.gameObject.transform.position += stackPoint.transform.up * gameObjectt.transform.localScale.y;


        }


        if (gameManager._listRight.Contains(this.gameObject))
        {
        
            gameManager._listRight.Remove(this.gameObject);
            gameManager.m -= 1;
            stackPointt.gameObject.transform.position += stackPointt.transform.up * gameObjectt.transform.localScale.y;

        }
        

        transform.SetParent(null);


        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = enabled;


        

    }
}