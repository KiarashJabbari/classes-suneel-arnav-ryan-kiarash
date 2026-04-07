using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 12f;
    public Tilemap wallTilemap;

    public bool IsMoving;
    public bool HasMoved;

    private Vector2 _targetPosition;
    private Grid _grid;

    void Start()
    {
        _grid = FindObjectOfType<Grid>();
        SnapToGrid();
        _targetPosition = transform.position;
    }

    void Update()
    {
        if (IsMoving)
        {
            MoveToTarget();
            return;
        }

        Vector2 dir = Vector2.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) dir = Vector2.up;
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) dir = Vector2.down;
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) dir = Vector2.left;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) dir = Vector2.right;

        if (dir != Vector2.zero)
            TryMove(dir);
    }

    void TryMove(Vector2 dir)
    {
        Vector2 next = _targetPosition + dir;
        Vector3Int cell = _grid.WorldToCell(new Vector3(next.x, next.y, 0));

        if (!wallTilemap.HasTile(cell))
        {
            _targetPosition = next;
            IsMoving = true;
            HasMoved = true;
        }
    }

    void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _targetPosition) < 0.01f)
        {
            transform.position = _targetPosition;
            IsMoving = false;
        }
    }

    void SnapToGrid()
    {
        if (_grid == null) return;
        transform.position = _grid.GetCellCenterWorld(_grid.WorldToCell(transform.position));
    }
}