using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SimpleJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Transform playerTransform; // Assign the player's transform to this in the inspector
    public float speed = 5f;
    public float boostedSpeed = 10f; // Speed when boosted
    public float stopDelay = 0.5f; // Adjust this to set the delay before stopping player movement
    public Button boostButton; // Assign the UI button to this in the inspector

    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;
    private float timeSinceLastTouch = 0f;
    private bool isBoosted = false;

    void Start()
    {
        if (boostButton != null)
        {
            EventTrigger trigger = boostButton.gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry();
            pointerDownEntry.eventID = EventTriggerType.PointerDown;
            pointerDownEntry.callback.AddListener((data) => { OnPointerDown((PointerEventData)data); });
            trigger.triggers.Add(pointerDownEntry);

            EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry();
            pointerUpEntry.eventID = EventTriggerType.PointerUp;
            pointerUpEntry.callback.AddListener((data) => { OnPointerUp((PointerEventData)data); });
            trigger.triggers.Add(pointerUpEntry);
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                pointA = touchPos;
                pointB = touchPos;
                touchStart = true;
                timeSinceLastTouch = 0f;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                pointB = touchPos;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                touchStart = false;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (!touchStart)
            {
                pointA = Input.mousePosition;
                pointB = Input.mousePosition;
                touchStart = true;
                timeSinceLastTouch = 0f;
            }
            else
            {
                pointB = Input.mousePosition;
            }
        }
        else
        {
            timeSinceLastTouch += Time.deltaTime;
            if (timeSinceLastTouch >= stopDelay)
            {
                touchStart = false;
            }
        }

        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            MovePlayer(direction * -1); // Reverse direction to match joystick convention
        }
        else
        {
            MovePlayer(Vector2.zero);
        }

        // Check if space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BoostPlayer();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            StopBoost();
        }
    }

    void MovePlayer(Vector2 direction)
    {
        float currentSpeed = isBoosted ? boostedSpeed : speed;
        playerTransform.Translate(direction * currentSpeed * Time.deltaTime);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        BoostPlayer();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopBoost();
    }

    void BoostPlayer()
    {
        isBoosted = true;
    }

    void StopBoost()
    {
        isBoosted = false;
    }
}
