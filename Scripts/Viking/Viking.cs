using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viking : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private float _speed;

    private Vector2 _moveDirection;
    private IVikingMoveController _vikingMoveController;

    public int Hp { 
        get => _hp; 
        set 
        {
            if (_hp == value) return;
            _hp = value;
            OnHPEqualBelowZero?.Invoke(_hp);
        } 
    }
    public float Speed { get => _speed; set => _speed = value; }

    private delegate void OnHPEqualBelowZeroDelegate(int hp);
    private event OnHPEqualBelowZeroDelegate OnHPEqualBelowZero;

    private void Awake()
    {
        _vikingMoveController = new VikingMoveController();
        _moveDirection = _vikingMoveController.CalcRandomVikingDirection();
        OnHPEqualBelowZero += ListenHPCount;
    }

    private void Start()
    {
        Debug.Log($"HP: {_hp}, Speed: {_speed}");
    }

    private void Update()
    {
        _vikingMoveController.VikingMove(transform, _speed, _moveDirection);
    }

    private void ListenHPCount(int hp)
    {
        if (hp <= 0)
        {
            OnHPEqualBelowZero -= ListenHPCount;
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreText>().ScoreCount++;
            GameObject.FindGameObjectWithTag("EnemiesCount").GetComponent<EnemiesCountText>().EnemiesCount--;
        }
    }

    public void ResetHP()
    {
        Hp = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("XBorder"))
            _moveDirection = _vikingMoveController.ReverseDirectionXAxis(_moveDirection);
        else if (collision.gameObject.CompareTag("YBorder"))
            _moveDirection = _vikingMoveController.ReverseDirectionYAxis(_moveDirection);
    }

    private void OnMouseDown()
    {
        Hp--;
    }
}
