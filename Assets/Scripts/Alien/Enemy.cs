using Enums;
using UnityEngine;

public class Enemy : MortalEntity
{
    public bool HasPet;

    public GoalZone GoalZone;

    private Move _moveScript;
    private Animator _animator;
    private static readonly int _rotate = Animator.StringToHash("Rotate");

    private void Start()
    {
        _moveScript = GetComponent<Move>();
        _animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(GameObjectTag.FreePet.ToString()) && !HasPet)
        {
            Transform pet = other.transform;
            pet.SetParent(transform);
            pet.transform.localPosition = Vector2.zero;
            pet.tag = GameObjectTag.CapturedPet.ToString();
            pet.GetComponent<Pet>().IsFree = false;
            _moveScript.ChangeTarget(GoalZone.GetRandomTargetZone());
            _animator.SetTrigger(_rotate);
            HasPet = true;
            CountManager.Instance.Decrement(CounterTag.Pets, 1); 
        }

        if (other.gameObject.GetComponent<GoalZone>() != null)
        {
            Debug.Log("OOPS!");
            ObjectPoolManager.Instance.ReturnToPool(PoolTag.Aliens, gameObject);
        }

        if(other.gameObject.CompareTag(GameObjectTag.PetSpawner.ToString()) && CountManager.Instance.GetCounter(CounterTag.Pets) == 0)
        {
            UIManager.Instance.ShowGameOverPanel();
        }
    }

    protected override void Die()
    {
        if (HasPet)
        {
            var pet = transform.GetChild(0);
            pet.SetParent(null);
            pet.GetComponent<Pet>().GoHome();
            CountManager.Instance.Increment(CounterTag.Pets, 1);
        }

        HasPet = false;
        GameObject particle = ObjectPoolManager.Instance.GetFromPool(PoolTag.EnemyLimbs);
        particle.transform.position = transform.position;
        
        CountManager.Instance.Increment(CounterTag.Kills, 1);
        CountManager.Instance.Increment(CounterTag.TotalKills, 1);
        CountManager.Instance.Increment(CounterTag.Scores, 1);

        ObjectPoolManager.Instance.ReturnToPool(PoolTag.Aliens, gameObject);
    }
}
