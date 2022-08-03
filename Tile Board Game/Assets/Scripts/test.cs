 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    private void Awake() {
        Debug.Log("awake");
    }

    private void OnEnable() {
        Debug.Log("enable");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        print("update");
    }

    private void FixedUpdate() {
        Debug.Log("fixed update");
    }

    private void LateUpdate() {
        Debug.Log("late update");
    }

    private void OnApplicationQuit() {
        Debug.Log("quit");
    }

    private void OnDisable() {
        Debug.Log("disable");
    }
}
