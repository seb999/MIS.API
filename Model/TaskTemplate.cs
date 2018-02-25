using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class TaskTemplate
    {
        public TaskTemplate()
        {
            TaskTemplateItem = new HashSet<TaskTemplateItem>();
        }

        public long TaskTemplateId { get; set; }
        public string TaskTemplateCode { get; set; }
        public string TaskTemplateName { get; set; }
        public string TaskTemplateDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<TaskTemplateItem> TaskTemplateItem { get; set; }
    }
}
