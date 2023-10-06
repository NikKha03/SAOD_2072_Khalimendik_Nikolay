namespace Queue {
    class QueueEmptyException : Exception {
        public QueueEmptyException(string message) : base(message) {
        }
    }
}