using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneController : MonoBehaviour
{
    [SerializeField] private Transform player1;

    private SpriteRenderer spriteRender;

    private PlayerMovement moveScript;

    private readonly int moveSpeed = 16;

    private float xMin, xMax;
    private float yMin, yMax;

    private void Awake()
    {
        moveScript = player1.GetComponent<PlayerMovement>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        var spriteSize = spriteRender.bounds.size.x * 0.5f;

        var cam = Camera.main;
        var camHeight = cam.orthographicSize;
        var camWidth = cam.orthographicSize * cam.aspect;

        yMin = -camHeight + spriteSize;//lower bound
        yMax = camHeight - spriteSize;// upper bound

        xMin = -camWidth + spriteSize;//left bound
        xMax = camWidth - spriteSize;// right bound

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = 1;
        }

        inputVector *= moveSpeed * Time.deltaTime;

        var xValidPosition = Mathf.Clamp(transform.position.x + inputVector.x, xMin, xMax);
        var yValidPosition = Mathf.Clamp(transform.position.y + inputVector.y, yMin, yMax);

        transform.position = new Vector3(xValidPosition, yValidPosition, 0f);
    }
}
