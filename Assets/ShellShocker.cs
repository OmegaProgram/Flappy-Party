using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellShocker : PowerUp
{
    [SerializeField]
    private GameObject shell;
    public override void PowerUpFunction()
    {
      //spawn two new shells and shrink them to 0.5
        GameObject newShell = Instantiate(shell);
        GameObject newShell1 = Instantiate(shell);
        Destroy(gameObject);
    }
}
