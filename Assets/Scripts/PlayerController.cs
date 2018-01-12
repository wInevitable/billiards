using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

  public float speed;
  public Text countText;
  public Text winText;

  private Rigidbody rb;
  private int count;

  // Start is called on the first frame that the script is active
  // often the very first frame of the game
  void Start () {
    count = 0;
    SetCountText();
    rb = GetComponent<Rigidbody>();
    winText.text = "";
  }

  // called before rendering a frame
  // most game code will go here
  void Update () {

  }

  // called before performing any physics calculations
  // physics-related code will go here
  void FixedUpdate () {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

    rb.AddForce (movement * speed);
  }

  void OnTriggerEnter (Collider other) {
    if (other.gameObject.CompareTag("Pick Up")) {
      other.gameObject.SetActive(false);
      count = count + 1;
      SetCountText();
    }
  }

  void SetCountText () {
    countText.text = "Count: " + count.ToString();
    if (count >= 12) {
      winText.text = "You Win!";
    }
  }
}
