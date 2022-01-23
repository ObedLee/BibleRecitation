namespace BibleRecitation
{
    class BibleVerse
    {
        private string head;
        private string body;

        public BibleVerse(string head, string body)
        {
            this.head = head;
            this.body = body;
        }

        public string Head
        {
            get { return head; }
            set { head = value; }
        }

        public string Body
        {
            get { return body; }
            set { body = value; }
        }
        
    }
}
