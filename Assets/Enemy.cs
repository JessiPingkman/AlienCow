using UnityEngine;

public class Enemy : MortalEssence
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
            pet.tag = Tags.FreePet.ToString();
            moveScript.ChangeTarget(goalZone.GetRandomZone());
            animator.SetTrigger(Rotate);
            hasPet = true;
        }
    }

    public override void Die()
    {
        if (hasPet)
        {
            var pet = transform.GetChild(0);
            pet.SetParent(null);
            pet.GetComponent<Pet>().GoHome();
        }

        hasPet = false;
        gameObject.SetActive(false);
    }
}
