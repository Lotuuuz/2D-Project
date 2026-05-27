using UnityEngine;

public class GrandmaController : MonoBehaviour
{
    //isLooking = bestemoren ser på spilleren (red light)
    //Når isLooking == false -> green light (spilleren kan gå)
    public bool isLooking = false;
   
    // hvor lenge hun ser på deg
    public float minLookTime = 2f;
    public float maxLookTime = 4f;
 
    // hvor lenge hun ser bort 
    public float minIdleTime = 2f;
    public float maxIdleTime = 4f;

    // timer teller ned til neste state-skifte 
    private float timer;

    public Animator animator;   

    void Start()
    {
        // setter første timer basert på om hun ser eller ikke
        SetNewTimer();

        animator.SetBool("isLooking", isLooking);
    }

    void Update()
    {

        //timer teller ned hver frame 
        timer -= Time.deltaTime;


        //når timer == 0 -> bytt mellom å se og ikke 
        if (timer <= 0)
        {
            isLooking = !isLooking;  //bytter state mellom rød og grønn


            animator.SetBool("isLooking", isLooking);

            SetNewTimer();  // random variasjon mellom se opp og ned 


 
        }
    }

    void SetNewTimer()
    {
        timer = isLooking ? Random.Range(minLookTime, maxLookTime)
                          : Random.Range(minIdleTime, maxIdleTime);
    }
}
