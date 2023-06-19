namespace BehaviourTree
{
    public class BTSequence : BTNode
    {
        private BTNode[] children;
        private int currentIndex = 0;
        public BTSequence(params BTNode[] _children)
        {
            children = _children;
        }

        public override BTResult Run()
        {
            for (; currentIndex < children.Length; currentIndex++)
            {
                BTResult result = children[currentIndex].Run();
                switch (result)
                {
                    case BTResult.Failed:
                        currentIndex = 0;
                        return BTResult.Failed;

                    case BTResult.Running:
                        return BTResult.Running;

                    case BTResult.Succes: break;
                }
            }
            currentIndex = 0;
            return BTResult.Succes;
        }
    }
}