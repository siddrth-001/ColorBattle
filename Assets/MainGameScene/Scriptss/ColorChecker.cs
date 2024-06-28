using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class ColorChecker : MonoBehaviour
{

#region Variables  

    [SerializeField] AudioSource SoundPlayer;
    [SerializeField] AudioClip RightClick , WrongChick;
    [SerializeField] GameObject[] Frames;
    [SerializeField] Button[] ColorButtons;
    private int Count = 0;
    private int Points =0;
    private int ButtonCount = 0;
    private GameObject MainCounter;
    private Color Pickup;
    [SerializeField] GameObject EndGamePanel;
    private float timer=0;
    [SerializeField] TextMeshProUGUI TextPoint,ScoreText;


#endregion Variables 

#region StartRegion

    void Start()
    {
        
        InvokeRepeating("GeneratePoints", 1f, 1.0f - timer);
        EndGamePanel.SetActive(false);
    }
#endregion StartRegion 

#region UpdateFunction
void Update()
{
     timer += Time.deltaTime*5; 
     if(timer>.8f)
     {
        timer =.8f;
     }
}

#endregion UpdateFunction
#region Instansiation

    public void GeneratePoints()
    {
        int SpawnPosition = Random.Range(-4, 4);                                                                                             //For Instansiation of Gameobject in Perticular Range**
        var newObject = Instantiate(Frames[Random.Range(0, Frames.Length)],new Vector3(SpawnPosition, 10, 15),Quaternion.identity);          //For Instansiation with New Name
        Count += 1;
        newObject.name = Count.ToString(); //For New Name to the Instaniated Object
    }
#endregion Instansiation 

#region ButtonClick

    public void OnClickButton()
    {
        foreach (Button button in ColorButtons)
        {
            if (button.gameObject == UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject)
            {
                Pickup = button.colors.pressedColor;
                Debug.Log(Pickup + "ButtonColor");
            }
        }
        ButtonCount += 1;
        MainCounter = GameObject.Find(ButtonCount.ToString());

        if (MainCounter)
        {
            if (Pickup == MainCounter.GetComponent<SpriteRenderer>().color)
            {
                SoundPlayer.PlayOneShot(RightClick);
                Points+=1;
                Debug.Log("Now Distroy the Tile on press of same Color");
                Destroy(GameObject.Find(ButtonCount.ToString()));
                TextPoint.text = Points.ToString();
            }
            else
            {
                TextPoint.gameObject.SetActive(false);
                ScoreText.gameObject.SetActive(false);
                SoundPlayer.PlayOneShot(WrongChick);
                Invoke("WrongTileSelected",1f);
                
            }
        }
        else
        {
            Debug.Log("Not Active");
        }
    }
#endregion ButtonClick  


#region WrongTile

 public void WrongTileSelected()
 {
    Debug.Log("Incorect TIle is Pused");
    EndGamePanel.SetActive(true);
    gameObject.GetComponent<ColorChecker>().enabled=false;
 }

#endregion WrongTile


#region ReStart

public void GameReStart()
{
    SceneManager.LoadScene(0);
} 

#endregion ReStart

}
