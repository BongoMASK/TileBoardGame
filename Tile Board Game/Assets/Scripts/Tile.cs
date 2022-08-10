using UnityEngine;

public class Tile : MonoBehaviour {
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    public Tile up;
    public Tile down;
    public Tile left;
    public Tile right;

    public enum TileState {
        red = 0,
        blue,
        white
    }

    [SerializeField] TileState tileState = TileState.white;

    void OnMouseEnter() {
        _highlight.SetActive(true);
    }

    private void OnMouseOver() {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Push_Right();
            ChangeTileState(TileState.white);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Push_Left();
            ChangeTileState(TileState.white);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            Push_Up();
            ChangeTileState(TileState.white);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            Push_Down();
            ChangeTileState(TileState.white);
        }
    }

    private void OnMouseExit() {
        _highlight.SetActive(false);
    }

    private void OnMouseDown() {
        ChangeTileState((TileState)GameManager.Instance.colorIndex);
    }

    public void Init() {
        _renderer.color = _offsetColor;
    }

    public void ChangeColour(int i) {
        _renderer.color = GameManager.Instance.colors[i];
    }

    public void SetDirectionData() {
        Vector2 tilePos = transform.position;

        up = GetTileAtPos(tilePos + new Vector2(0, 1));
        down = GetTileAtPos(tilePos + new Vector2(0, -1));
        left = GetTileAtPos(tilePos + new Vector2(-1, 0));
        right = GetTileAtPos(tilePos + new Vector2(1, 0));
    }

    Tile GetTileAtPos(Vector2 pos) {
        if (GridManager._tiles.ContainsKey(pos))
            return GridManager._tiles[pos];
        return null;
    }

    void ChangeTileState(TileState thisTileState) {
        tileState = thisTileState;
        ChangeColour((int)thisTileState);
    }

    void Push_Right() {
        // if there are no tiles left
        if (right == null) {
            ChangeTileState(left.tileState);
            return;
        }

        // if tile is not white, shift to next tile
        if (tileState != TileState.white)
            right.Push_Right();

        // shift left to tile to current tile
        if (left == null) {
            ChangeTileState(TileState.white);
            return;
        }
        ChangeTileState(left.tileState);
        
    }

    void Push_Left() {
        // if there are no tiles left
        if (left == null) {
            ChangeTileState(right.tileState);
            return;
        }

        // if tile is not white, shift to next tile
        if (tileState != TileState.white)
            left.Push_Left();

        // shift left to tile to current tile
        if (right == null) {
            ChangeTileState(TileState.white);
            return;
        }
        ChangeTileState(right.tileState);
    }

    void Push_Up() {
        // if there are no tiles left
        if (up == null) {
            ChangeTileState(down.tileState);
            return;
        }

        // if tile is not white, shift to next tile
        if (tileState != TileState.white)
            up.Push_Up();

        // shift left to tile to current tile
        if (down == null) {
            ChangeTileState(TileState.white);
            return;
        }
        ChangeTileState(down.tileState);
    }

    void Push_Down() {
        // if there are no tiles left
        if (down == null) {
            ChangeTileState(up.tileState);
            return;
        }

        // if tile is not white, shift to next tile
        if (tileState != TileState.white)
            down.Push_Down();

        // shift left to tile to current tile
        if (up == null) {
            ChangeTileState(TileState.white);
            return;
        }
        ChangeTileState(up.tileState);
    }
}
