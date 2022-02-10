using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SphereController : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 20f;
    [SerializeField] private Vector3 _changeScale = new Vector3(.02f, .02f, .02f);
    public List<GameObject> numbers = new List<GameObject>();
    private int i = 0;
    private int j = 0;

    private void Start()
    {
        Mathf.Clamp(i, 0, 12);
        Mathf.Clamp(j, 0, 12);
    }

    private void OnMouseDrag()
    {
        float rotateY = Input.GetAxis("Mouse Y") * _rotateSpeed * Mathf.Deg2Rad;
        transform.RotateAround(Vector3.right, rotateY);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            NumberSpawn();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            NumberDestroy();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Grow();
        }

        if (Input.GetKey(KeyCode.E))
        {
            Shrink();
        }
    }
    private void Shrink()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale - _changeScale, 1f);
    }
    
    private void Grow()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale + _changeScale, 1f);
    }
    private void NumberSpawn()
    {
        
            numbers[i].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            numbers[i].transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
            numbers[i].transform.GetChild(2).GetComponent<Canvas>().enabled = true;
            i++;
    }

    private void NumberDestroy()
    {
        
        
            numbers[j].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            numbers[j].transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
            numbers[j].transform.GetChild(2).GetComponent<Canvas>().enabled = false;
            j++;
        
        
    }
}
