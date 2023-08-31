using UnityEngine;

//could use inheritance to simplify this
//have a base class called controller which then branches of into player two and one controller
// controler can have move speed min and maxes 

namespace Assets.Scripts
{
    public class PlayerTwoController : MonoBehaviour
    {
        [SerializeField] private Transform player2;

        private SpriteRenderer spriteRender;

        private PlayerMovement moveScript;

        private readonly int moveSpeed = 16;

        private float xMin, xMax;
        private float yMin, yMax;

        private void Awake()
        {
            moveScript = player2.GetComponent<PlayerMovement>();
            spriteRender = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            var spriteSize = spriteRender.bounds.size.x * 0.5f;

            var cam = Camera.main;
            var camHeight = cam.orthographicSize;
            var camWidth = cam.orthographicSize * cam.aspect;

            yMin = -camHeight + spriteSize; //lower bound
            yMax = camHeight - spriteSize; // upper bound

            xMin = -camWidth + spriteSize; //left bound
            xMax = camWidth - spriteSize; // right bound

        }

        // Update is called once per frame
        void Update()
        {
            Vector2 inputVector = new Vector2(0, 0);

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                inputVector.x = -1;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                inputVector.y = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                inputVector.y = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                inputVector.x = 1;
            }

            inputVector *= moveSpeed * Time.deltaTime;

            var xValidPosition = Mathf.Clamp(transform.position.x + inputVector.x, xMin, xMax);
            var yValidPosition = Mathf.Clamp(transform.position.y + inputVector.y, yMin, yMax);

            transform.position = new Vector3(xValidPosition, yValidPosition, 0f);

            Vector2 vel = GetComponent<Rigidbody2D>().velocity;

            Debug.Log("player 2 velocity");
            Debug.Log(vel);
        }
    }
}