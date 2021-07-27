using System;
using System.Collections.Generic;

namespace frontend.Pages{


    [Serializable]
    public class ResponseQuiz : RequestQuiz{
        public int Id { get; set; }

    }

   [Serializable]
    public class RequestQuiz{
         public string title { get; set; }

        public Int64 owner { get; set; }

        public List<Question> questions { get; set; } = new List<Question>();
    }

    [Serializable]
    public class Question{
        public int Id { get; set; }

        public string Query { get; set; }

        public List<Answer> Answers { get; set; } = new List<Answer>();
    }

    [Serializable]
    public class Answer{
        public int Id { get; set; }

        public string Text { get; set; }

        public int Points { get; set; }
    }
}