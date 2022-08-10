using UnityEngine;

public class Tile : MonoBehaviour {
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    DirectionData direction = new DirectionData();

    public void Init() {
        _renderer.color = _offsetColor;
    }

    void OnMouseEnter() {
        _highlight.SetActive(true);
    }

    void OnMouseExit() {
        _highlight.SetActive(false);
    }

    private void OnMouseDown() {
        if (GameManager.Instance.currentColor == Color.white) {
            Init();
            return;
        }
        ChangeColour(GameManager.Instance.currentColor);
    }
    public void ChangeColour(Color color) {
        _renderer.color = color;
    }

    void setDirectionData()
    {

    }
}
