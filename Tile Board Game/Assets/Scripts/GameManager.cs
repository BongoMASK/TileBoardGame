using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    [SerializeField] Color[] colors;

    [SerializeField] public Color currentColor;

    private void Awake()
    {
        currentColor = colors[0];

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void PickColour(int i)
    {
        if (i >= colors.Length)
        {
            currentColor = Color.white;
            return;
        }
        currentColor = colors[i];
    }
}
