using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float Speed;
    public Text CountText;
    public Text WinText;
    
    private Rigidbody _rb;
    private int _count;

    // Use this for initialization
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _count = 0;
        SetCountText();
        WinText.text = "";
    }

    private void FixedUpdate()
    {
        Vector3 movement;
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                movement = new Vector3(Input.acceleration.x, 0, -Input.acceleration.z);
                break;
            default:
                movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                break;
        }
        _rb.AddForce(movement * Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            _count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        CountText.text = "Count: " + _count;
        if (_count >= 12)
        {
            WinText.text = "You Win!";
        }
    }
}