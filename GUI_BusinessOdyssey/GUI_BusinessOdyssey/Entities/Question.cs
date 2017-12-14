using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_BusinessOdyssey.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int? QuestionPoints { get; set; }
        public double? QuestionWeight { get; set; }
        public int? ScoreSheetId { get; set; }

        public ScoreSheet ScoreSheet { get; set; }
    }
}
