using UnityEngine;
public class EnemyController : ItemSpawner, IHitable 
{
    [SerializeField] private  float movementSpeed = 1;
    [SerializeField] private  float timeToTurn = 3;
    [SerializeField] private  float actualTimeTurn = 0;
    [SerializeField] private  int score = 0;
    // Update is called once per frame
    void Update()
    {
        if (actualTimeTurn > 0)
        {
            actualTimeTurn -= Time.deltaTime;
        }
        else
        {
            RaycastTurn();
        }
        
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.5f))
        {
            if(hit.transform.gameObject.layer == 11)
            {
                hit.transform.gameObject.GetComponent<IHitable>().OnHit();
            }
            else
            {
                transform.Rotate(0, 180, 0);
            }
        }
    }
    void RaycastTurn()
    {
        int turnDirection = 0;
        turnDirection = Random.Range(1, 3);
        RaycastHit hit;
        if(turnDirection == 1)
        {
            if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 0.5f))
            {
                transform.Rotate(0, 90, 0);
                transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y,
                    Mathf.Round(transform.position.z));
            }
        }
        else if (turnDirection == 2)
        {
            if (!Physics.Raycast(transform.position, transform.TransformDirection( Vector3.left), out hit, 0.5f))
            {
                transform.Rotate(0, -90, 0);
                transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y,
                    Mathf.Round(transform.position.z));
            }
        }
        actualTimeTurn = timeToTurn;
    }
    public void OnHit()
    {
        SpawnItem();
        LevelManager.Get().UpdateEnemies();
        LevelManager.Get().UpdateScore(score);
        Destroy(gameObject);
    }
    public override void SpawnItem()
    {
        base.SpawnItem();
    }
}
