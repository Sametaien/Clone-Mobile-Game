using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LeftLeg : MonoBehaviour
{
    public static event Action OnLeftShoesCollected;

    private List<int> _one = new List<int>();


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "item")
        {
            
            if (!_one.Contains(1))
            {
                Destroy(other.gameObject);
                OnLeftShoesCollected?.Invoke();
                _one.Add(1);
            }
        }
        else
        {
            if (_one.Contains(1))
            {
                _one.Remove(1);
            }
        }
    }

    

}
