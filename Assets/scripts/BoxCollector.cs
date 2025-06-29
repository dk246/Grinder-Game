using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BoxCollector : MonoBehaviour
{
    private int coinCount = 0;
    public Text coinText;
    //private float speedOfGrinder;


    [SerializeField] private Button gravityBtn, speedBtn, gameSpeed2x,amountBtn, spawnBtn;
    [SerializeField] private GameObject initBtn;
    //[SerializeField] private int gameSpeed2xActivator;

    public GameObject[] allBoxes, grinders;

    public Slider levelSlider;
    [SerializeField] private Text levelTxt, gravityCoinText, speedCoinText, gameSpeedCoinText, gameSpeedText, amountText, amountCoinText;
    [SerializeField] private Text  gravityValueText, speedValueText, spawnText,spawnCoinText;
    //private int lvlCount; 
    private int level ;
    private int minVal;
    //private int maxVal;
    [SerializeField] private Button levelUpBtn;




    // Start is called before the first frvame update
    void Start()
    {
        coinCount = PlayerPrefs.GetInt("coin");
        coinText.text = "" + coinCount.ToString();


        gravityBtn.interactable = false;
        speedBtn.interactable = false;
        gameSpeed2x.interactable = false;
        levelUpBtn.interactable = false;
        amountBtn.interactable = false;
        spawnBtn.interactable = false;

        if (PlayerPrefs.GetInt("init") == 10)
        {
            initBtn.SetActive(false);
            levelSlider.maxValue = PlayerPrefs.GetInt("maxVal");
   
        }
        else
        {
            Time.timeScale = 0;
            initBtn.SetActive(true);
            //levelSlider.maxValue = PlayerPrefs.GetInt("maxVal");
            //print("here");
        }

        
        //gravityActivator = 50;
        //speedActivator = 80;
        //speedOfGrinder = 100;
        //gameSpeed2xActivator = 30;
        minVal = 0; 
        levelSlider.minValue = minVal;

        //Initialize();
        starting();
    }

    private void starting()
    {
        gravityValueText.text = PlayerPrefs.GetFloat("gravityValue").ToString();
        speedValueText.text = PlayerPrefs.GetFloat("speedValue").ToString();
        gameSpeedText.text = PlayerPrefs.GetFloat("timeScale").ToString() + "x";
        gameSpeedText.text = Time.timeScale.ToString() + "x";
        amountText.text = "Lvl:" + PlayerPrefs.GetInt("AmountNow").ToString();
        //gravityValueText.text = PlayerPrefs.GetFloat("gravityValue").ToString();
        speedValueText.text = PlayerPrefs.GetFloat("speedValue").ToString();
        spawnText.text = PlayerPrefs.GetFloat("spawn").ToString();
    }

    public void Initialize()
    {
        PlayerPrefs.SetInt("maxVal", 100);
        levelSlider.maxValue = PlayerPrefs.GetInt("maxVal");
        PlayerPrefs.SetInt("init", 10);
        PlayerPrefs.SetInt("gravityActivator", 50);
        PlayerPrefs.SetInt("speedActivator", 80);
        PlayerPrefs.SetInt("GameSpeedActivator", 300);
        PlayerPrefs.SetInt("amountActivator", 1000);
        //PlayerPrefs.SetInt("Activator", 1);
        PlayerPrefs.SetInt("AmountNow", 1);

        PlayerPrefs.SetInt("spawnActivator", 300);
        //PlayerPrefs.SetInt("Activator", 1);
        PlayerPrefs.SetFloat("spawn", 5);
        PlayerPrefs.SetFloat("gravityValue", 10.0f);
        PlayerPrefs.SetFloat("speedValue", 100.0f);

        //amountText.text = "Lvl:" + PlayerPrefs.GetInt("AmountNow").ToString();

        initBtn.SetActive(false);

        for (int i = 0; i < allBoxes.Length; i++)
        {
            allBoxes[i].GetComponent<Rigidbody2D>().gravityScale = 1f;

        }

        Time.timeScale = 1;
        starting();
    }
    // Update is called once per frame
    void Update()
    {
      
        gravityCoinText.text = "coin:" + PlayerPrefs.GetInt("gravityActivator").ToString();
        speedCoinText.text = "coin:" + PlayerPrefs.GetInt("speedActivator").ToString();
        gameSpeedCoinText.text = "coin:" + PlayerPrefs.GetInt("GameSpeedActivator").ToString();
        amountCoinText.text = "coin:" + PlayerPrefs.GetInt("amountActivator").ToString();
        spawnCoinText.text = "coin:" + PlayerPrefs.GetInt("spawnActivator").ToString();

        levelTxt.text = PlayerPrefs.GetInt("level").ToString();
        levelSlider.value = PlayerPrefs.GetInt("lvlCount");

        if (PlayerPrefs.GetInt("gravityActivator") < coinCount)
        {
            gravityBtn.interactable = true;
        }
        else
        {
            gravityBtn.interactable = false;
        }
        if (PlayerPrefs.GetInt("speedActivator") < coinCount)
        {
            speedBtn.interactable = true;
        }
        else
        {
            speedBtn.interactable = false;
        }
        if (PlayerPrefs.GetInt("GameSpeedActivator") < coinCount)
        {
            gameSpeed2x.interactable = true;
        }
        else
        {
            gameSpeed2x.interactable = false;
        }
        if (PlayerPrefs.GetInt("amountActivator") < coinCount)
        {
            amountBtn.interactable = true;
        }
        else
        {
            amountBtn.interactable = false;
        }
        if (PlayerPrefs.GetInt("spawnActivator") < coinCount)
        {
            spawnBtn.interactable = true;
        }
        else
        {
            spawnBtn.interactable = false;
        }


        if (levelSlider.value == levelSlider.maxValue)
        {
            levelUpBtn.interactable = true;
        }
        else
        {
            levelUpBtn.interactable = false;
        }
        


        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "small")
        {
            coinCount++;
            int lvlCount;
            lvlCount = PlayerPrefs.GetInt("lvlCount");
            lvlCount++;
            PlayerPrefs.SetInt("lvlCount", lvlCount);
            coinBalance();

        }
        else if (collision.tag == "spSmall")
        {
            coinCount += 2;
            int lvlCount;
            lvlCount = PlayerPrefs.GetInt("lvlCount");
            lvlCount++;
            PlayerPrefs.SetInt("lvlCount", lvlCount);

            coinBalance();

        }
    }
    public void Amount()
    {
        int tempAmountActivator = 1000;
        int amountNow;
        amountBtn.interactable = false;
        amountNow = PlayerPrefs.GetInt("AmountNow");
        amountNow++;
        coinCount -= PlayerPrefs.GetInt("amountActivator");
        coinBalance();
        tempAmountActivator = PlayerPrefs.GetInt("amountActivator") + (PlayerPrefs.GetInt("amountActivator") * 7 - PlayerPrefs.GetInt("amountActivator") * 4);
        PlayerPrefs.SetInt("amountActivator", tempAmountActivator);
        PlayerPrefs.SetInt("AmountNow", amountNow);
        amountCoinText.text = "coin:" + PlayerPrefs.GetInt("amountActivator").ToString();
        amountText.text = "Lvl:" + PlayerPrefs.GetInt("AmountNow").ToString();
    }

    public void Spawn()
    {
        int tempSpawnActivator = 300;
        float SpawnNow;
        spawnBtn.interactable = false;
        SpawnNow = PlayerPrefs.GetFloat("spawn");
        SpawnNow -= 0.2f;
        coinCount -= PlayerPrefs.GetInt("spawnActivator");
        coinBalance();
        tempSpawnActivator = PlayerPrefs.GetInt("spawnActivator") + (PlayerPrefs.GetInt("spawnActivator") * 7 - PlayerPrefs.GetInt("spawnActivator") * 4);
        PlayerPrefs.SetInt("amountActivator", tempSpawnActivator);
        PlayerPrefs.SetFloat("AmountNow", SpawnNow);
        amountCoinText.text = "coin:" + PlayerPrefs.GetInt("spawnActivator").ToString();
        amountText.text = "Lvl:" + PlayerPrefs.GetFloat("spawn").ToString();
    }

    public void gravityScale()
    {
        float temp = 0f;
        int tempGravity = 10;
        gravityBtn.interactable = false;
        coinCount -= PlayerPrefs.GetInt("gravityActivator");
        coinBalance();
        tempGravity = PlayerPrefs.GetInt("gravityActivator") + (PlayerPrefs.GetInt("gravityActivator") * 7 - PlayerPrefs.GetInt("gravityActivator") * 4);
        PlayerPrefs.SetInt("gravityActivator", tempGravity);
        for (int i = 0; i < allBoxes.Length; i++)
        {
            allBoxes[i].GetComponent<Rigidbody2D>().gravityScale += 0.2f;
            if(i == 0)
            {
                temp = allBoxes[i].GetComponent<Rigidbody2D>().gravityScale;
            }
        }
       
        PlayerPrefs.SetFloat("gravityValue", temp+5);
        gravityValueText.text = PlayerPrefs.GetFloat("gravityValue").ToString();
    }

    public void SpeedIncrese()
    {
        float tempSpeedGrinder = 100.0f;
        int tempSpeedActivator = 0;
        speedBtn.interactable = false;
        coinCount -= PlayerPrefs.GetInt("speedActivator");
        coinBalance();
        tempSpeedActivator = PlayerPrefs.GetInt("speedActivator") + (PlayerPrefs.GetInt("speedActivator") * 7 - PlayerPrefs.GetInt("speedActivator") * 3);
        PlayerPrefs.SetInt("speedActivator", tempSpeedActivator);
        tempSpeedGrinder = PlayerPrefs.GetFloat("speedValue") + (PlayerPrefs.GetFloat("speedValue") * 0.05f);
        grinders[0].GetComponent<RotateObject>().rotationSpeed = -PlayerPrefs.GetFloat("speedValue");
        grinders[1].GetComponent<RotateObject>().rotationSpeed = PlayerPrefs.GetFloat("speedValue");


        PlayerPrefs.SetFloat("speedValue", tempSpeedGrinder);
        speedValueText.text = PlayerPrefs.GetFloat("speedValue").ToString();
    }

    public void gameSpeed()
    {
        int tempGameSpeedActivator = 300;
        Time.timeScale = Time.timeScale + 0.2f;
        gameSpeed2x.interactable = false;
        coinCount -= PlayerPrefs.GetInt("GameSpeedActivator");
        coinBalance();
        tempGameSpeedActivator = PlayerPrefs.GetInt("GameSpeedActivator") + (PlayerPrefs.GetInt("GameSpeedActivator") * 7 - PlayerPrefs.GetInt("GameSpeedActivator") * 4);
        PlayerPrefs.SetInt("GameSpeedActivator", tempGameSpeedActivator);
        PlayerPrefs.SetFloat("timeScale", Time.timeScale);
        gameSpeedText.text = PlayerPrefs.GetFloat("timeScale").ToString()+"x";
    }

    public void LevelUp()
    {
        levelUpBtn.interactable = false;
        level++;
        PlayerPrefs.SetInt("level", level);
        level = PlayerPrefs.GetInt("level");
        levelSlider.value = 0;
        //levelSlider.maxValue = PlayerPrefs.GetInt("maxVal") + level * (PlayerPrefs.GetInt("maxVal") + 1);
        PlayerPrefs.SetInt("maxVal", (PlayerPrefs.GetInt("maxVal") + level * (PlayerPrefs.GetInt("maxVal") + 1)));
        PlayerPrefs.SetInt("lvlCount", 0);
        levelSlider.maxValue = PlayerPrefs.GetInt("maxVal");

    }

    private void coinBalance()
    {
        PlayerPrefs.SetInt("coin", coinCount);
        coinCount = PlayerPrefs.GetInt("coin");
        coinText.text = "coin:" + coinCount.ToString();
    }



}
