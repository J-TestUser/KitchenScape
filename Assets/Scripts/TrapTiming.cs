using UnityEngine;
using System.Collections;

public class TrapTiming : MonoBehaviour
{

    private Animator _animator;
    public int delay=3;
    public int _endingDelay=3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    IEnumerator TrapDelay()
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            _animator.SetBool("IsActive", true);
            yield return new WaitForSeconds(_endingDelay);
            _animator.SetBool("IsActive", false);
        }
    }

    void Start()
    {
        StartCoroutine(TrapDelay());
    }
}
