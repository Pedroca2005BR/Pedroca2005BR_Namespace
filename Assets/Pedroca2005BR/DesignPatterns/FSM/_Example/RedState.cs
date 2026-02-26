using UnityEngine;


namespace Pedroca2005BR.DesignPatterns.FSM._Example
{
    public class RedState : BaseState<CubeBehaviour>
    {
        string[] musics = new string[] { "Elevador", "Passaro", "Caverna", "Monster", "Spin" };
        int index = 0;

        // TO DO: Use Timer to lock music change for a few seconds after each change

        public RedState(CubeBehaviour context) : base(context)
        {
            AudioManager.instance.PlaySound(musics[index]);
        }

        public override void EnterState()
        {
            context.GetComponent<Renderer>().material.color = Color.red;
        }

        public override void ExitState()
        {
            Debug.Log("Exiting Red State");
        }

        public override void UpdateState()
        {
            if (context.MoveInput.x > 0)
            {
                AudioManager.instance.StopSound(musics[index]);
                index = (index + 1) % musics.Length;
                AudioManager.instance.PlaySound(musics[index]);
            }
            else if (context.MoveInput.x < 0)
            {
                AudioManager.instance.StopSound(musics[index]);
                index = (index - 1);
                if (index < 0)
                    index = musics.Length - 1;
                AudioManager.instance.PlaySound(musics[index]);
            }
        }
    }
}

