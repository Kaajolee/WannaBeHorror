using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cameraOBJ;
    private AudioListener audioListener;
    private AudioSource audioSource;
    public Canvas playerUI;
    //public GameObject player;
    void Start()
    {

        cameraOBJ.SetActive(false);
        audioListener = cameraOBJ.GetComponent<AudioListener>();
        audioSource = cameraOBJ.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            JumpScareCall(other.gameObject);
        }
    }
    IEnumerator JSCancel(GameObject player)
    { 
        yield return new WaitForSeconds(5);
        player.SetActive(true);
        Toggle();
    }
    private void Toggle()
    {
        playerUI.enabled=true;
        audioListener.enabled = false;
        cameraOBJ.SetActive(false);
        gameObject.SetActive(false);
    }
    public void JumpScareCall(GameObject player)
    {
        audioListener.enabled = true;
        //Debug.Log("Collision entered");
        playerUI.enabled = false;
        player.SetActive(false);
        cameraOBJ.SetActive(true);
        audioSource.Play();
        StartCoroutine(JSCancel(player));
    }
}
