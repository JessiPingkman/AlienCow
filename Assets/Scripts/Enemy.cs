using Enums;
using UnityEngine;

public class Enemy : MortalEntity
{
    public bool hasPet = false;

    public GoalZone goalZone;

    private Move moveScript;
    private Animator animator;
    private static readonly int Rotate = Animator.StringToHash("Rotate");

    private void Start()
    {
        moveScript = GetComponent<Move>();
        animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Tags.FreePet.ToString()) && !hasPet)
        {
            Transform pet = other.transform;
            pet.SetParent(transform);
            pet.transform.localPosition = Vector2.zero;
            pet.tag = Tags.CapturedPet.ToString();
            pet.GetComponent<Pet>().isFree = false;
            moveScript.ChangeTarget(goalZone.GetRandomTargetZone());
            animator.SetTrigger(Rotate);
            hasPet = true;
            CountManager.Instance.Decrement(CounterTags.pets, 1); 
        }

        if (other.gameObject.GetComponent<GoalZone>() != null)
        {
            Debug.Log("OOPS!");
            ObjectPoolManager.Instance.ReturnToPool(PoolTags.Aliens, gameObject);
        }

        if(other.gameObject.CompareTag(Tags.PetSpawner.ToString()) && CountManager.Instance.GetCounter(CounterTags.pets) == 0)
        {
            UIManager.Instance.ShowGameOverPanel();
        }
    }

    protected override void Die()
    {
        if (hasPet)
        {
            var pet = transform.GetChild(0);
            pet.SetParent(null);
            pet.GetComponent<Pet>().GoHome();
            CountManager.Instance.Increment(CounterTags.pets, 1);
        }

        hasPet = false;
        CountManager.Instance.Increment(CounterTags.kills, 1);
        CountManager.Instance.Increment(CounterTags.totalKills, 1);
        CountManager.Instance.Increment(CounterTags.scores, 1);
        ObjectPoolManager.Instance.ReturnToPool(PoolTags.Aliens, gameObject);
    }
}
