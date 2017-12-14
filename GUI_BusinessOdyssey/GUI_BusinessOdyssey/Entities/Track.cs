using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_BusinessOdyssey.Entities
{
    public class Track
    {
        public int TrackId { get; set; }
        public string TrackName { get; set; }

        public ObservableCollection<ScoreSheet> ScoreSheet { get; set; }
        public ObservableCollection<ScoreSheetReg> ScoreSheetReg { get; set; }
    }
}
