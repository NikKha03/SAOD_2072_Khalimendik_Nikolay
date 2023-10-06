namespace Queue {
    class QueueOverflowException : Exception {
        public QueueOverflowException(string message) : base(message) { 
        }
    }
}