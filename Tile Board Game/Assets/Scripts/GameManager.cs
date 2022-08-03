using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    [SerializeField] Color[] colors;

    [SerializeField] public Color currentColor;

    [SerializeField] TMP_Text numText1, numText;

    [SerializeField] public TMP_Text turnCounter;

    public int turns = 0;

    private int maxNum = 6; 

    private void Awake() {
        currentColor = colors[0];

        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
        }
    }    

    public void PickColour(int i) {
        if(i >= colors.Length) {
            currentColor = Color.white;
            return;
        }
        currentColor = colors[i];
    }

    public void GenerateRandomNumber() {
        numText.text = Random.Range(1, maxNum + 1).ToString();
        numText1.text = Random.Range(1, maxNum + 1).ToString();
        turns += 1;
        turnCounter.text = turns.ToString();
    }

    public void ResetTurns() {
        turns -= 1;
        turnCounter.text = turns.ToString();
    }
}
