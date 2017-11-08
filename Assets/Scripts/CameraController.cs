using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject Player;
	
	private Vector3 _offset;

	// Use this for initialization
	private void Start ()
	{
		_offset = transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	private void LateUpdate()
	{
		transform.position = Player.transform.position + _offset;
	}
}
