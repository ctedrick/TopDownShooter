using UnityEngine;

public class Controller : MonoBehaviour {
	[SerializeField] private float moveSpeed;

	private Rigidbody rb;
	private Camera viewCamera;
	private Vector3 velocity;
	
	private void Start() {
		rb = GetComponent<Rigidbody>();
		viewCamera = Camera.main;
	}

	private void Update() {
		var mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,viewCamera.transform.position.y));
		transform.LookAt(mousePos + Vector3.up * transform.position.y);
		velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
	}

	private void FixedUpdate() => rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
}