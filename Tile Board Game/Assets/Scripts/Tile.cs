using UnityEngine;

public class Tile : MonoBehaviour {

    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    public Tile[] borders;

    public enum TileBorder {
        up = 0,
        down,
        left,
        right
    }

    enum TileState {
        red = 0,
        blue,
        white
    }

    // try to use events and scriptable objects

    [SerializeField] TileState tileState = TileState.white;

    // Checking how many consecutive same coloured tiles are there
    int GetPushPower(TileState firstTileState, TileBorder b) {
        if (firstTileState == TileState.white || firstTileState != tileState)
            return 0;

        if (borders[(int)b] == null)
            return 1;

        return 1 + borders[(int)b].GetPushPower(firstTileState, b);
    }

    // Checking the next tile that is coloured
    Tile TraverseTile(TileBorder b) {
        if (tileState != TileState.white)
            return this;

        if (borders[(int)b] == null)
            return null;

        return borders[(int)b].TraverseTile(b);
    }

    private void OnMouseEnter() {
        _highlight.SetActive(true);
    }

    private void OnMouseOver() {
        if (GameManager.Instance.colorIndex != (int)tileState)
            return;

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            // Find consecutive same coloured tiles for pushing power
            int p = GetPushPower(tileState, TileBorder.right);

            // Continue until pushpower is not finished
            while (p-- > 0)
                TraverseTile(TileBorder.right).Push_Right();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            // Find consecutive same coloured tiles for pushing power
            int p = GetPushPower(tileState, TileBorder.left);

            // Continue until pushpower is not finished
            while (p-- > 0)
                TraverseTile(TileBorder.left).Push_Left();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            // Find consecutive same coloured tiles for pushing power
            int p = GetPushPower(tileState, TileBorder.up);

            // Continue until pushpower is not finished
            while (p-- > 0)
                TraverseTile(TileBorder.up).Push_Up();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            // Find consecutive same coloured tiles for pushing power
            int p = GetPushPower(tileState, TileBorder.down);

            // Continue until pushpower is not finished
            while (p-- > 0)
                TraverseTile(TileBorder.down).Push_Down();
        }
    }

    private void OnMouseExit() {
        _highlight.SetActive(false);
    }

    // Applying colour to white tile
    private void OnMouseDown() {
        ChangeTileState((TileState)GameManager.Instance.colorIndex);
    }

    // Changes tile colour and state
    void ChangeTileState(TileState thisTileState) {
        if (tileState != TileState.white) 
            return;
        
        tileState = thisTileState;
        _renderer.color = GameManager.Instance.colors[(int)thisTileState];
        SwitchTurn();
    }

    // Sets borders for the tile
    public void SetDirectionData() {
        Vector2 tilePos = transform.position;

        borders[(int)TileBorder.up] = GetTileAtPos(tilePos + new Vector2(0, 1));        // up
        borders[(int)TileBorder.down] = GetTileAtPos(tilePos + new Vector2(0, -1));     // down
        borders[(int)TileBorder.left] = GetTileAtPos(tilePos + new Vector2(-1, 0));     // left
        borders[(int)TileBorder.right] = GetTileAtPos(tilePos + new Vector2(1, 0));     // right
    }

    Tile GetTileAtPos(Vector2 pos) {
        if (GameManager.Instance._tiles.ContainsKey(pos))
            return GameManager.Instance._tiles[pos];
        return null;
    }

    void Push_Right() {
        Push(TileBorder.right, TileBorder.left);
        ChangeTileState(TileState.white);
        SwitchTurn();
    }

    void Push_Left() {
        Push(TileBorder.left, TileBorder.right);
        ChangeTileState(TileState.white);
        SwitchTurn();
    }

    void Push_Up() {
        Push(TileBorder.up, TileBorder.down);
        ChangeTileState(TileState.white);
        SwitchTurn();
    }

    void Push_Down() {
        Push(TileBorder.down, TileBorder.up);
        ChangeTileState(TileState.white);
        SwitchTurn();
    }

    void Push(TileBorder b1, TileBorder b2) {
        // if there are no tiles left
        if (borders[(int)b1] == null) {
            ChangeTileState(borders[(int)b2].tileState);
            return;
        }

        // if tile is not white, check next tile
        if (tileState != TileState.white)
            borders[(int)b1].Push(b1, b2);

        // If null, delete the current tile
        if (borders[(int)b2] == null) {
            ChangeTileState(TileState.white);
            return;
        }
        // shift previous tile to current tile if null
        ChangeTileState(borders[(int)b2].tileState);
    }
    private static void SwitchTurn() {
        if (GameManager.Instance.colorIndex == 0) {
            GameManager.Instance.colorIndex = 1;
            return;
        }
        GameManager.Instance.colorIndex = 0;
    }
}