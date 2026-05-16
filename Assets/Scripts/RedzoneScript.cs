using UnityEngine;
using UnityEngine.InputSystem;

public class RedzoneScript : MonoBehaviour
{

    public GameObject slider;
    public GameObject redzone;
    public GameObject bar;

    public float leftSideBar;
    public float rightSideBar;

    private bool movingRight = true;
    public float speed = 5f;

    private bool stopSlider;
    private bool noRepeat;


    //private float redzoneSizeOffset;


    void Start()
    {
        // offset for when redzone will be different sizes,, but idk how to make the button function take in a variable 
        //redzoneSizeOffset = redzone.transform.localScale.x / 2f;
        //Debug.Log(redzoneSizeOffset);

    }





    void Update()
    {
        
        // when active(because of button), slider moves back and forth in bar
        if (this.gameObject.activeSelf && !stopSlider)
        {
            if (movingRight)
            {
                slider.transform.Translate(Vector2.right * speed * Time.deltaTime);
                if (slider.transform.position.x >= rightSideBar)
                {
                    movingRight = false;
                }
            }
            else
            {
                slider.transform.Translate(Vector2.left * speed * Time.deltaTime);
                if (slider.transform.position.x <= leftSideBar)
                {
                    movingRight = true;
                }
            }
        }

        // when space is pressed, stops slider, checks if slider is in redzone, and either prints hit or miss. then waits for 1 second and sets inactive
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !noRepeat)
        {
            noRepeat = true;
            stopSlider = true;

            if (this.gameObject.activeSelf)
            {
                if (slider.transform.position.x >= redzone.transform.position.x - 0.5f && slider.transform.position.x <= redzone.transform.position.x + 0.5f)
                {
                    Debug.Log("hit!");
                }
                else
                {
                    Debug.Log("miss!");
                }
            }

            Invoke("Inactivate", 1f);


        }


    }


    void Inactivate()
    {
        this.gameObject.SetActive(false);
    }




    public void ResetSlider()
    {
        // when button pressed, activate slider if not active, and set slider to the left side and redzone randomly in the bar
        if (!this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(true);
            stopSlider = false;
            noRepeat = false;
            slider.transform.position = new Vector3(leftSideBar, slider.transform.position.y, slider.transform.position.z);
            redzone.transform.position = new Vector3(Random.Range(leftSideBar + 0.5f, rightSideBar - 0.5f), redzone.transform.position.y, redzone.transform.position.z);

            return;
        }
        else
        {
            return;
        }
    }



}







