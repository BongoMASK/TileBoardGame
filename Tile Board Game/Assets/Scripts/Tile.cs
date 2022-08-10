using UnityEngine;

public class Tile : MonoBehaviour {
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    public Tile up;
    public Tile down;
    public Tile left;
    public Tile right;


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


    public void Init()
    {
        _renderer.color = _offsetColor;
    }
    public void ChangeColour(Color color) {
        _renderer.color = color;
    }
    public void setDirectionData()
    {
        Vector2 tilePos = transform.position;

        if(GridManager._tiles.ContainsKey(tilePos+ new Vector2(0, 1)))
        {
            up = GridManager._tiles[tilePos + new Vector2(0, 1)];
        }

        if(GridManager._tiles.ContainsKey(tilePos+ new Vector2(0, -1)))
        {
            down = GridManager._tiles[tilePos + new Vector2(0, -1)];
        }
        if(GridManager._tiles.ContainsKey(tilePos+ new Vector2(-1, 0)))
        {
            left = GridManager._tiles[tilePos + new Vector2(-1, 0)];
        }

        if(GridManager._tiles.ContainsKey(tilePos + new Vector2(1, 0)))
        {
            right = GridManager._tiles[tilePos + new Vector2(1, 0)];
        }
    }
}
