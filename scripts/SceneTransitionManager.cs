using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    // The Transform component of the target object that the camera should follow.
    public Transform target;

    

    // A reference to the PlayerController component on the player object.
    private PlayerController playerController;

    private void Awake()
    {
        // Get a reference to the PlayerController component on the player object.
        //playerControllerP = target.GetComponent<PlayerController>().protected;
    }


    public GameObject Game1;
    public GameObject Game2;
    public Transform BlueSun;
    public Transform Sun;

    private void Update()
    {
        //thunderSound.Play();
        if (BlueSun.position.y >= Sun.position.y)
        {
            Game2.SetActive(true);
            Game1.SetActive(false);

        }
        else
        {
            Game2.SetActive(false);
            Game1.SetActive(true);  
        }
    }
}