namespace BehaviourTree
{
    public abstract class BTNode
    {
        public enum BTResult { Succes, Failed, Running }
        public abstract BTResult Run();
    }
}