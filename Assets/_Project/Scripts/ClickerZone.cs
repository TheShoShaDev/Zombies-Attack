using UnityEngine;
using UnityEngine.EventSystems;

public class ClickerZone : MonoBehaviour, IPointerClickHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject _xMark;
    private bool _isDragging = false;
    private Vector2 _offset;

    public void OnPointerClick(PointerEventData eventData)
    {
        _isDragging = true;
        _offset = _xMark.transform.position - eventData.pointerCurrentRaycast.worldPosition;
        SetXmark(eventData);
    }

    public void SetXmark(PointerEventData eventData)
    {
        _xMark.transform.position = eventData.pointerCurrentRaycast.worldPosition;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (_isDragging)
        {
            Vector3 newPosition = (Vector3)eventData.pointerCurrentRaycast.worldPosition;
            _xMark.transform.position = newPosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _isDragging = false;
    }
}