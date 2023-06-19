namespace BehaviourTree
{
    public class BTSelector : BTNode
    {
        private BTNode[] children;
        public BTSelector(params BTNode[] _children)
        {
            children = _children;
        }

        public override BTResult Run()
        {
            foreach (BTNode node in children)
            {
                switch (node.Run())
                {
                    case BTResult.Failed:
                        continue;
                    case BTResult.Succes:
                        return BTResult.Succes;
                    case BTResult.Running:
                        return BTResult.Running;
                    default:
                        continue;
                }
            }
            return BTResult.Failed;
        }
    }
}