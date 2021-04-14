namespace towerdef.Helpers.EventQueue
{
    public class QueueMessage
    {
        public string Message { get; set; }

        public float DisplayTime { get; set; }

        public QueueMessage()
        {
        }

        public QueueMessage(string msg, float dt)
        {
            Message = msg;
            DisplayTime = dt;
        }
    }
}
