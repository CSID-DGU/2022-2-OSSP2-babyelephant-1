using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TransferMap : MonoBehaviour
{
    public string transferMapName;

    public Transform target;
    public BoxCollider2D targetBound;

    private PlayerManager thePlayer;
    private CameraManager theCamera;

    // Start is called before the first frame update
    void Start()
    {
        theCamera = FindObjectOfType<CameraManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name=="Player")
        {
            thePlayer.currentMapName = transferMapName;
            theCamera.SetBound(targetBound);
            //SceneManager.LoadScene(transferMapName);
            theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = target.transform.position;
        }
    }
}
