using UnityEngine;

public class RFIDObject : MonoBehaviour
{
    [SerializeField] private string _cardUID;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void OnDetected()
    {
        _renderer.material.color = Color.green;
        Debug.Log($"Detected card UID: {_cardUID}");
    }

    public void OnLost()
    {
        _renderer.material.color = Color.white;
        Debug.Log($"Lost card UID: {_cardUID}");
    }
}
