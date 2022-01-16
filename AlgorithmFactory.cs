namespace AI.Search
{
    public enum AlgorithmType
    {
        Both,
        StackFrontier,
        QueueFrontier
    }

    public class AlgorithmFactory
    {
        public ISearchAlgorithm GetAlgorithm(AlgorithmType type)
        {
            switch (type)
            {
                case AlgorithmType.QueueFrontier:
                    return new QueueFrontier();
                default:
                case AlgorithmType.StackFrontier:
                    return new StackFrontier();
            }
        }
    }
}