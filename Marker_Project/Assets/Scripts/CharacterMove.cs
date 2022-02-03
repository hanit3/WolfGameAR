using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMove : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    [SerializeField]
    private RectTransform lever;
    private RectTransform rectTransform;

    [SerializeField, Range(10, 150)]
    private float leverRange;

    private Vector2 inputDirection;
    private bool isInput;

    [SerializeField]
    private TPSCharacterController controller;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
        isInput = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
        isInput = false;
        controller.Move(Vector2.zero);

    }

    private void ControlJoystickLever(PointerEventData eventData)
    {
        var inputPos = eventData.position - rectTransform.anchoredPosition;
        var inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;
        lever.anchoredPosition = inputVector;    
        inputDirection = inputVector / leverRange;
    }

    private void InputControlVector()
    {
        // 캐릭터에게 이동 벡터 전달
        controller.Move(inputDirection);
        //Debug.Log(inputDirection.x + "/" + inputDirection.y);
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInput)
        {
            InputControlVector();

        }
    }
}
