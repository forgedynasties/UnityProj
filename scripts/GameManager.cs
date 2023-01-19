using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI speed;
    [SerializeField] private GameObject bike;
    // Start is called before the first frame update

    public GameObject pauseMenu;
    public GameObject gameOver;
    public GameObject controls;
    void Start()
    {
        pauseMenu.SetActive(false);
        gameOver.SetActive(false);
        controls.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        int scoref = ((int)((bike.transform.position.x - 92.3f) * -1))/10;
        score.text = scoref.ToString();
        speed.text = ((int)bike.GetComponent<Rigidbody>().velocity.magnitude).ToString();
    }

   public void gameOverf()
    {
        gameOver.SetActive(true);
        controls.SetActive(false);
    }
}
