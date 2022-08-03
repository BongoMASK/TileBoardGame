using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    public void Init(bool isOffset) {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    void OnMouseEnter() {
        _highlight.SetActive(true);
    }

    void OnMouseExit() {
        _highlight.SetActive(false);
    }

    private void OnMouseDown() {
        if (GameManager.Instance.currentColor == Color.white) {
            Init(true);
            return;
        }

        GameManager.Instance.turns += 1;
        GameManager.Instance.turnCounter.text = GameManager.Instance.turns.ToString();
        ChangeColour(GameManager.Instance.currentColor);
    }

    public void ChangeColour(Color color) {
        _renderer.color = color;
    }
}
