using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private List<GameObject> players = new List<GameObject>();
    private float _dis;
    private float _previousDis;
    private float _displayer;
    private int playerindex;
    private Rigidbody2D rb;

    [SerializeField] private Transform ballpoint;
    [SerializeField] private float ballRadius;
    [SerializeField] private LayerMask ballLayerMask;

    private Collider2D _ball;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        foreach (var player in GameManager.instance.players)
        {
            players.Add(player);
        }
    }

    private void Update()
    {
        _ball = Physics2D.OverlapCircle(ballpoint.position, ballRadius, ballLayerMask);

        if (_ball != null)
        {
            return;
        }
        else
        {
            if (rb.velocity.x <= 0 && rb.velocity.y <= 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    _dis = Vector2.Distance(transform.position, players[i].transform.position);

                    if (i == 0)
                    {
                        _previousDis = _dis;
                    }

                    if (_previousDis < _dis)
                    {
                        _displayer = _previousDis;
                        _previousDis = _dis;
                    }
                    else if (_previousDis > _dis)
                    {
                        if (_displayer > _dis)
                        {
                            _displayer = _dis;
                        }
                        _previousDis = _dis;
                    }

                    if (_displayer == _dis)
                    {
                        playerindex = i;
                    }
                }
                transform.position = players[playerindex].transform.position;
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(ballpoint.position, ballRadius);
    }
}
