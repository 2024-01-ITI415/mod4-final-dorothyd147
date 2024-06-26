using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
 // Rigidbody of the player.
 private Rigidbody rb; 

 // Variable to keep track of collected "PickUp" objects.
 private int count;
 private int ghostRemaining;

 // UI text component to display count of "PickUp" objects collected.
 public TextMeshProUGUI countText;

 public AudioClip pickupSound;

 // UI object to display winning text.
 public GameObject winTextObject;

 // Start is called before the first frame update.
 void Start()
    {
 // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();

 // Initialize count to zero.
        count = 10;

 // Update the count display.
        SetCountText();

 // Initially set the win text to be inactive.
        winTextObject.SetActive(false);
    }
 
 void OnTriggerEnter(Collider other) 
    {
 // Check if the object the player collided with has the "PickUp" tag.
 if (other.gameObject.CompareTag("PickUp")) 
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);

 // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);

 // Increment the count of "PickUp" objects collected.
            count = count - 1;


 // Update the count display.
            SetCountText();
        }
    }

 // Function to update the displayed count of "PickUp" objects collected.
 void SetCountText() 
    {
 // Update the count text with the current count.
        countText.text = "Ghosts Left: " + count.ToString();

 // Check if the count has reached or exceeded the win condition.
 if (count <= 0)
        {
 // Display the win text.
            winTextObject.SetActive(true);
        }
    }
}