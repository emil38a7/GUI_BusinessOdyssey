using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_BusinessOdyssey.Entities
{
    public class ScoreSheet
    {
        public int ScoreSheetId { get; set; }
        public string ScoreSheetCategory { get; set; }
        public int TrackId { get; set; }

        public Track Track { get; set; }
        public ObservableCollection<Question> Question { get; set; }
    }
}
