using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float moveInterval = 0.4f;
    public Tilemap wallTilemap;

    private Vector2 _targetPosition;
    private Grid _grid;
    private Transform _player;
    private bool _isMoving;
    private float _moveTimer;
    private bool _activated;

    void Start()
    {
        _grid = FindObjectOfType<Grid>();
        _player = FindObjectOfType<PlayerController>().transform;
        SnapToGrid();
        _targetPosition = transform.position;
        _moveTimer = moveInterval;
    }

    void Update()
    {
        if (!_activated)
        {
            if (FindObjectOfType<PlayerController>().HasMoved)
                _activated = true;
            else
                return;
        }

        if (_isMoving)
        {
            MoveToTarget();
            return;
        }

        _moveTimer -= Time.deltaTime;
        if (_moveTimer <= 0f)
        {
            _moveTimer = moveInterval;
            TakeStep();
        }
    }

    void TakeStep()
    {
        var path = BFS(WorldToCell(_targetPosition), WorldToCell(_player.position));
        if (path != null && path.Count > 1)
        {
            _targetPosition = CellToWorld(path[1]);
            _isMoving = true;
        }
    }

    List<Vector2Int> BFS(Vector2Int start, Vector2Int goal)
    {
        var queue = new Queue<Vector2Int>();
        var cameFrom = new Dictionary<Vector2Int, Vector2Int>();

        queue.Enqueue(start);
        cameFrom[start] = start;

        Vector2Int[] dirs = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current == goal)
                return Reconstruct(cameFrom, start, goal);

            foreach (var d in dirs)
            {
                var next = current + d;
                if (cameFrom.ContainsKey(next)) continue;
                if (next != goal && IsWall(next)) continue;
                cameFrom[next] = current;
                queue.Enqueue(next);
            }
        }

        return null;
    }

    List<Vector2Int> Reconstruct(Dictionary<Vector2Int, Vector2Int> cameFrom, Vector2Int start, Vector2Int goal)
    {
        var path = new List<Vector2Int>();
        var current = goal;
        while (current != start)
        {
            path.Add(current);
            current = cameFrom[current];
        }
        path.Add(start);
        path.Reverse();
        return path;
    }

    bool IsWall(Vector2Int cell) => wallTilemap.HasTile(new Vector3Int(cell.x, cell.y, 0));

    Vector2Int WorldToCell(Vector3 pos)
    {
        var c = _grid.WorldToCell(pos);
        return new Vector2Int(c.x, c.y);
    }

    Vector2 CellToWorld(Vector2Int cell) => _grid.GetCellCenterWorld(new Vector3Int(cell.x, cell.y, 0));

    void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, _targetPosition) < 0.01f)
        {
            transform.position = _targetPosition;
            _isMoving = false;
        }
    }

    void SnapToGrid()
    {
        if (_grid == null) return;
        transform.position = _grid.GetCellCenterWorld(_grid.WorldToCell(transform.position));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            GameManager.Instance?.OnPlayerDeath();
    }
}