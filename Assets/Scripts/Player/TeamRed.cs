using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamRed : MonoBehaviour
{
    [SerializeField] private float kickRadius;
    [SerializeField] private float kickSpeed;
    [SerializeField] private Transform kickPoint;
    [SerializeField] private LayerMask kickLayerMask;
    [SerializeField] private Transform spawnPoint;

    private Vector3 maxX, minX, totalDistance;
    private float _speed;
    private Slider _slider;
    private string tagname;
    private Animator _animator;
    private Collider2D _ball;
    private float _xlimit = 0.789f;

    private int _kickAnimatorId;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _kickAnimatorId = Animator.StringToHash("Kick");
        _slider = GameObject.FindGameObjectWithTag("SliderRed").GetComponent<Slider>();
        tagname = this.tag;
        if(tagname == "TeamRed6")
        {
            _slider.onValueChanged.AddListener(UpdatePosition);
        }
    }

    public void UpdatePosition(float value)
    {
        transform.position = new Vector3(value * _xlimit,transform.position.y,0f );
    }

    void FixedUpdate()
    {

        _ball = Physics2D.OverlapCircle(kickPoint.position, kickRadius, kickLayerMask);

        /*if (_ball)
        {
            Rigidbody2D rb = _ball.GetComponent<Rigidbody2D>();
            if (rb.velocity.x <= 0 && rb.velocity.y <= 0.1)
            {
                _ball.transform.position = spawnPoint.transform.position; 
            }

        }*/
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider != null && hit.collider.tag == tagname)
            {
                _animator.SetTrigger(_kickAnimatorId);
                if (_ball)
                {
                    FindObjectOfType<Audio_Manager>().Play("Kick");
                    int randomx = Random.Range(-1, 1);
                    int randomy = Random.Range(-2, 0);
                    Rigidbody2D rb = _ball.GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(randomx * kickSpeed, randomy * kickSpeed));
                }
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(kickPoint.position, kickRadius);
    }

}
