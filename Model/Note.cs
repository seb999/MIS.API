using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class Note
    {
        public long NoteId { get; set; }
        public long? ActivityId { get; set; }
        public long? UserId { get; set; }
        public string NoteContent { get; set; }
        public bool? NoteIsImportant { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Activity Activity { get; set; }
        public UserApplication User { get; set; }
    }
}
